using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishProject 
{
    public partial class Edit : Form
    {
        public Edit() 
        {
            InitializeComponent(); // Form üzerindeki bileşenleri (kontrolleri) başlatmak için metot.
        }

        int userID; 

        public Edit(int userID) // Kullanıcı kimliğini parametre olarak alan ikinci bir yapılandırıcı
        {
            InitializeComponent(); // Form üzerindeki bileşenleri (kontrolleri) başlatmak için metot.
            this.userID = userID; // Parametre olarak gelen kullanıcı kimliğini sınıf değişkenine atar.
        }

        private void btnSave_Click(object sender, EventArgs e) 
        {
            string wordTr = tbWordTR.Text; // Türkçe kelimeyi tbWordTR kontrolünden alır.
            string wordEn = tbWordEN.Text; // İngilizce kelimeyi tbWordEN kontrolünden alır.
            string wordSentence = tbSentence.Text; // Cümleyi tbSentence kontrolünden alır.
            string wordImage = tbPicture.Text; // Resim yolunu tbPicture kontrolünden alır.
            
            Connect.con.Open(); // Veritabanı bağlantısını açar.
            SqlCommand cmd = new SqlCommand(); // Yeni bir SqlCommand nesnesi oluşturur.
            cmd.Connection = Connect.con; // SqlCommand nesnesini veritabanı bağlantısına bağlar.

            // Kullanıcı kimliği, Türkçe kelime, İngilizce kelime, cümle, öğrenme durumu ve resim yolu ile veritabanına yeni bir kayıt ekler.
            cmd.CommandText = $"insert into Word (userID,wordTR,wordEN,wordSentence,isLearning,wordImage) values ('{userID}','{wordTr}','{wordEn}','{wordSentence}','0','{wordImage}')";
            cmd.ExecuteNonQuery(); // Sorguyu çalıştırır.
            
            Connect.con.Close(); // Veritabanı bağlantısını kapatır.
            MessageBox.Show("Word added SUCCESSFULLY"); // Başarılı ekleme mesajı gösterir.

            // Tüm metin kutularını temizler ve resim kutusunu boşaltır.
            tbWordTR.Clear(); 
            tbWordEN.Clear();
            tbSentence.Clear();
            tbPicture.Clear();
            pbImage.Image = null;
        }

        private void btnPictureAdd_Click(object sender, EventArgs e) 
        {
            openFileDialog1.ShowDialog(); // Dosya seçme diyalogunu açar.
            pbImage.ImageLocation = openFileDialog1.FileName; // Seçilen dosyanın yolunu pbImage kontrolüne atar.
            tbPicture.Text = openFileDialog1.FileName; // Seçilen dosyanın yolunu tbPicture kontrolüne atar.
        }
    }
}

