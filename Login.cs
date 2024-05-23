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

namespace EnglishProject // Proje için bir ad alanı tanımlıyor.
{
    public partial class Login : Form // Form sınıfından türeyen kısmi Login sınıfını tanımlıyor.
    {
        public Login() // Login sınıfı için yapılandırıcı
        {
            InitializeComponent(); // Form üzerindeki bileşenleri (kontrolleri) başlatmak için metot.
        }

        private void btnLogin_Click(object sender, EventArgs e) // btnLogin butonunun tıklanma olayı için olay işleyici
        {
            string username = tbName.Text; // tbName kontrolünden kullanıcı adını alıyor.
            Connect.con.Open(); // Veritabanı bağlantısını açıyor.
            SqlCommand cmd = new SqlCommand(); // Yeni bir SqlCommand nesnesi oluşturuyor.
            cmd.Connection = Connect.con; // SqlCommand nesnesini veritabanı bağlantısına bağlar.

            // Komut metnini SQL sorgusu olarak ayarlar, kullanıcı adı ve sabit parola ile.
            cmd.CommandText = $"select Count(*) as 'Count' from Users where username = '{username}' and password ='test'";
            int count = (int)cmd.ExecuteScalar(); // Sorguyu çalıştırır ve dönen sonucu integer olarak alır.

            if (count == 0) // Eğer count 0 ise (kullanıcı adı ve parola eşleşmiyorsa)
            {
                label1.Text = "Başarıyla giriş yapıldı"; // label1 kontrolüne mesaj yazdırır.
            }
            else // Eğer count 0 değilse (kullanıcı adı ve parola eşleşiyorsa)
            {
                label1.Text = "Giriş yapıldı"; // label1 kontrolüne mesaj yazdırır.
            }
            Connect.con.Close(); // Veritabanı bağlantısını kapatır.
        }

        private void Login_Load(object sender, EventArgs e) // Formun Load olayı için olay işleyici
        {
            // Bu metot form yüklendiğinde çağrılır.
        }
    }
}
