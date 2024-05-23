using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace EnglishProject 
{
    public partial class Fp : Form 
    {
        string randomCode; // Rastgele kodu tutmak için bir değişken tanımlıyor.
        public static string to; // Statik bir değişken tanımlıyor, bu değişken email adresini tutacak.
        SqlConnection conn = new SqlConnection(@"Data Source=YUSUFISLAMYANıK\SQLEXPRESS;Initial Catalog=EnglishProject;Integrated Security=True;Encrypt=True"); 
        
        public Fp() 
        {
            InitializeComponent(); // Form üzerindeki bileşenleri (kontrolleri) başlatmak için metot.
        }

        private void btnSend_Click(object sender, EventArgs e) 
        {
            string email = tbEmail.Text; // tbEmail kontrolünden email adresini alıyor.
            string from, pass, messageBody; // Email gönderimi için gerekli değişkenleri tanımlıyor.
            Random rand = new Random(); // Rastgele sayı oluşturucu tanımlıyor.
            randomCode = (rand.Next(999999)).ToString(); // 6 haneli rastgele bir sayı oluşturup stringe çeviriyor.
            MailMessage message = new MailMessage(); // Yeni bir MailMessage nesnesi oluşturuyor.
            to = (tbEmail.Text).ToString(); // Email adresini alıyor.
            from = "yazilimyapimiprojesi@gmail.com"; // Gönderici email adresini belirliyor.
            pass = "kysu zoyf bojj gdnj"; // Gönderici email adresinin şifresini belirliyor.
            messageBody = "your reset code is " + randomCode; // Mesaj gövdesini oluşturuyor.
            message.To.Add(to); // Alıcı email adresini ekliyor.
            message.From = new MailAddress(from); // Gönderici email adresini ekliyor.
            message.Body = messageBody; // Mesaj gövdesini ekliyor.
            message.Subject = "password reseting code"; // Mesaj konusunu belirliyor.
            SmtpClient smtp = new SmtpClient("smtp.gmail.com"); // SMTP istemcisi oluşturuyor ve Gmail SMTP sunucusunu kullanıyor.
            smtp.EnableSsl = true; // SSL kullanarak bağlantıyı güvenli hale getiriyor.
            smtp.Port = 587; // SMTP portunu belirliyor.
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // Teslimat yöntemini belirliyor.
            smtp.Credentials = new NetworkCredential(from, pass); // Gönderici kimlik bilgilerini belirliyor.

            try 
            {
                Connect.con.Open(); // Veritabanı bağlantısını açıyor.
                string query = "SELECT * FROM EnglishProject WHERE email = @email"; // Veritabanında email adresini aramak için sorgu oluşturuyor.
                SqlCommand cmd = new SqlCommand(query, conn); // SqlCommand nesnesi oluşturuyor ve sorguyu ekliyor.
                cmd.Parameters.AddWithValue("@email", email); // Sorgu parametresine email adresini ekliyor.
                smtp.Send(message); // Email mesajını gönderiyor.
                MessageBox.Show("code send successfully"); // Başarılı gönderim mesajı gösteriyor.
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); // Hata mesajını gösteriyor.
            }
        }

        private void btnCode_Click(object sender, EventArgs e) 
        {
            if (randomCode == (tbCode.Text).ToString()) // Girilen kod ile oluşturulan kod eşleşirse
            {
                to = tbEmail.Text; // Email adresini değişkene atar.
                Fp2 rp = new Fp2(); // Yeni bir Fp2 formu oluşturur.
                rp.ShowDialog(); // Fp2 formunu gösterir.
                this.Close(); // Mevcut formu kapatır.
            }
            else // Kodlar eşleşmezse
            {
                MessageBox.Show("wrong code"); // Hata mesajı gösterir.
            }
        }
    }
}

