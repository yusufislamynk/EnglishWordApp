using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishProject
{
    public partial class Exam : Form
    {
        // Sınavla ilgili değişkenler tanımlanıyor
        int currentWordIndex = 0;
        List<Word> wordList = new List<Word>();
        bool isExamFinish = false;
        List<string> choose = new List<string>();
        static Random random = new Random();
        int trueCount = 0;
        int falseCount = 0;

        // Exam form constructor
        public Exam()
        {
            InitializeComponent();
        }

        // Kullanıcı ID ve kelime resim değişkenleri tanımlanıyor
        public int userID;
        private string wordImage;

        // Kullanıcı ID ile Exam form constructor
        public Exam(int userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        // Form yüklendiğinde yapılacak işlemler
        private void Exam_Load(object sender, EventArgs e)
        {
            clearPage();
            getData();
        }

        // Veritabanından sınav için gerekli verileri getiren fonksiyon
        private void getData()
        {
            int questionCount = 5;
            Connect.con.Open();
            
            // Kullanıcının soru sayısını al
            string query1 = $"select questionCount from Users where userID = {userID}";
            SqlCommand cmd1 = new SqlCommand(query1, Connect.con);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                questionCount = Convert.ToInt32(reader1["questionCount"]);
            }
            reader1.Close();

            // Sınav için kelimeleri seç
            string query = $@"
            SELECT TOP {questionCount} *
            FROM Word 
            WHERE
                (isLearning = 1 AND (
                    replyDate = CAST(DATEADD(day, +1, GETDATE()) AS DATE) OR
                    replyDate = CAST(DATEADD(week, +1, GETDATE()) AS DATE) OR
                    replyDate = CAST(DATEADD(month, +1, GETDATE()) AS DATE) OR
                    replyDate = CAST(DATEADD(month, +3, GETDATE()) AS DATE) OR
                    replyDate = CAST(DATEADD(month, +6, GETDATE()) AS DATE) OR
                    replyDate = CAST(DATEADD(year, +1, GETDATE()) AS DATE)
                ))
                OR (isLearning = 0 AND userID = {userID})";

            SqlCommand cmd = new SqlCommand(query, Connect.con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            // Kelimeleri listeye ekle
            while (reader.Read())
            {
                int wordID = Convert.ToInt32(reader["wordID"]);
                string wordEN = reader["wordEN"].ToString();
                string wordTR = reader["wordTR"].ToString();
                string wordSentence = reader["wordSentence"].ToString();
                wordImage = reader["wordImage"].ToString();
                bool isLearning = Convert.ToBoolean(reader["isLearning"]);
                int userID = Convert.ToInt32(reader["userID"]);

                Word newWord = new Word
                {
                    WordID = wordID,
                    wordTR = wordTR,
                    wordEN = wordEN,
                    wordSentence = wordSentence,
                    isLearning = isLearning,
                    userID = userID
                };

                wordList.Add(newWord);
            }
            reader.Close();
            Connect.con.Close();

            ShowCurrentWord(wordList);
        }

        // Sayfayı temizle
        private void clearPage()
        {
            tbQuestion.Clear();
        }

        // Geçerli kelimeyi ekrana göster
        void ShowCurrentWord(List<Word> wordList)
        {
            if (wordList.Count == 0)
                return;

            Word currentWord = wordList[currentWordIndex];
            tbQuestion.AppendText($"{currentWord.wordSentence} \n{currentWord.wordEN}");
            getChooseData(wordList[currentWordIndex].WordID, wordList[currentWordIndex].wordTR);
        }

        // Buton A'ya tıklanma olayı
        private void btnA_Click(object sender, EventArgs e)
        {
            getNextQuestion(this.wordList);
            pictureBox1.ImageLocation = wordImage;
            this.Hide();
            addAnswerToReport(wordList[currentWordIndex - 1], btnA);
        }

        // Bir sonraki soruyu al
        private void getNextQuestion(List<Word> wordLists)
        {
            clearPage();
            if (currentWordIndex >= wordLists.Count - 1)
            {
                isExamFinish = true;
                MessageBox.Show("Exam is finished! You're redirecting to Rapor Page!");
                return;
            }

            currentWordIndex++;
            ShowCurrentWord(wordLists);
        }

        // Cevabı rapora ekle
        private void addAnswerToReport(Word answer, Button btnSelected)
        {
            bool isLearning;
            DateTime replyDate;
            if (btnSelected.Text == answer.wordTR)
            {
                trueCount += 1;
                isLearning = true;
            }
            else
            {
                falseCount += 1;
                isLearning = false;
            }
            replyDate = DateTime.Now.Date;
            Connect.con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = Connect.con;
            cmd1.CommandText = @"
            UPDATE Word
            SET replyDate = @replyDate,
            isLearning = @isLearning
            WHERE userID = @userID AND wordID = @wordID";

            using (cmd1)
            {
                cmd1.Parameters.AddWithValue("@replyDate", replyDate);
                cmd1.Parameters.AddWithValue("@isLearning", isLearning);
                cmd1.Parameters.AddWithValue("@userID", answer.userID);
                cmd1.Parameters.AddWithValue("@wordID", answer.WordID);

                cmd1.ExecuteNonQuery();
                Connect.con.Close();
            }

            if (isExamFinish)
            {
                // Sınav sonuçlarını log tablosuna ekle
                Guid examID = Guid.NewGuid();
                Connect.con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Connect.con;
                cmd.CommandText = $"insert into Log (userID, trueCount, falseCount, examID) values ('{answer.userID}', '{trueCount}', '{falseCount}', '{examID}')";
                cmd.ExecuteNonQuery();
                Connect.con.Close();
                GeneratePDFReport(answer.userID, examID.ToString(), trueCount, falseCount);
                Main mainForm = new Main();
                mainForm.Show();
                this.Hide();
            }
        }

        // Şıkları oluştur
        private void getChooseData(int wordid, string wordTRR)
        {
            Button[] buttons = { btnA, btnB, btnC, btnD };
            Connect.con.Open();
            string query = $"select TOP 3 wordTR from Word where wordID != {wordid}";

            SqlCommand cmd = new SqlCommand(query, Connect.con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string wordTR = reader["wordTR"].ToString();
                choose.Add(wordTR);
            }
            Random rnd = new Random();
            choose = choose.OrderBy(x => rnd.Next()).ToList();

            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < choose.Count)
                    buttons[i].Text = choose[i];
            }

            int correctButtonIndex = rnd.Next(buttons.Length);
            buttons[correctButtonIndex].Text = wordTRR;
            reader.Close();
            Connect.con.Close();
        }

        // PDF raporu oluştur
        private void GeneratePDFReport(int userid, string examId, int correctCount, int incorrectCount)
        {
            string userName = "";
            string name = "";
            string surname = "";
            string email = "";

            Connect.con.Open();
            string query = $"select * from Users where userID = {userid}";

            SqlCommand cmd = new SqlCommand(query, Connect.con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userName = reader["username"].ToString();
                name = reader["name"].ToString();
                surname = reader["surname"].ToString();
                email = reader["email"].ToString();
            }
            reader.Close();
            Connect.con.Close();

            double total = correctCount + incorrectCount;
            double successRate = (correctCount / total) * 100;

            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("ExamResults.pdf", FileMode.Create));
            document.Open();

            // PDF içeriği ekle
            Paragraph title = new Paragraph("Exam Results", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24f, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            Paragraph userNameParagraph = new Paragraph($"User Name: {userName}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            userNameParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(userNameParagraph);

            Paragraph nameParagraph = new Paragraph($"Name: {name}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            nameParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(nameParagraph);

            Paragraph surnameParagraph = new Paragraph($"Surname: {surname}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            surnameParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(surnameParagraph);

            Paragraph emailParagraph = new Paragraph($"Email: {email}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            emailParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(emailParagraph);

            Paragraph examIdParagraph = new Paragraph($"Exam Id: {examId}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            examIdParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(examIdParagraph);

            Paragraph userIdParagraph = new Paragraph($"User Id: {userid}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK));
            userIdParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(userIdParagraph);

            Paragraph correctCountParagraph = new Paragraph($"Correct Answer: {correctCount}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.GREEN));
            correctCountParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(correctCountParagraph);

            Paragraph incorrectCountParagraph = new Paragraph($"Wrong Answer: {incorrectCount}", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.RED));
            incorrectCountParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(incorrectCountParagraph);

            Paragraph successRateParagraph = new Paragraph($"Result: {successRate:N2}%", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLUE));
            successRateParagraph.Alignment = Element.ALIGN_CENTER;
            document.Add(successRateParagraph);

            document.Close();

            // PDF'i görüntüle
            System.Diagnostics.Process.Start("ExamResults.pdf");
        }

        // Buton B'ye tıklanma olayı
        private void btnB_Click(object sender, EventArgs e)
        {
            getNextQuestion(this.wordList);
            pictureBox1.ImageLocation = wordImage;
            addAnswerToReport(wordList[currentWordIndex - 1], btnB);
        }

        // Buton C'ye tıklanma olayı
        private void btnC_Click(object sender, EventArgs e)
        {
            LoadNextQuestion(wordList);
            pictureBox1.ImageLocation = wordImage;
            RecordAnswer(wordList[currentWordIndex - 1], btnC);
        }

        // Bir sonraki soruyu yükleyen fonksiyon
        private void LoadNextQuestion(List<Word> words)
        {
            getNextQuestion(words);
        }

        // Cevabı rapora ekleyen fonksiyon
        private void RecordAnswer(Word word, Button button)
        {
            addAnswerToReport(word, button);
        }

        // Buton D'ye tıklanma olayı
        private void btnD_Click(object sender, EventArgs e)
        {
            getNextQuestion(this.wordList);
            pictureBox1.ImageLocation = wordImage;
            addAnswerToReport(wordList[currentWordIndex - 1], btnD);
        }
    }
}
