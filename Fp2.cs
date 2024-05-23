using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EnglishProject
{
    public partial class Fp2 : Form
    {
        // Kullanıcı adı değişkeni, önceki formdan gelen veriyi tutar.
        string username = Fp.to;

        public Fp2()
        {
            InitializeComponent();
        }

        private void Fp2_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler (eğer varsa) buraya eklenebilir.
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            // İki şifre alanının aynı olup olmadığını kontrol et
            if (tbPassword.Text == tbPasswordAgain.Text)
            {
                // Veritabanı bağlantısını aç
                using (SqlConnection con = new SqlConnection("Data Source=YUSUFISLAMYANıK\\SQLEXPRESS;Initial Catalog=EnglishProject;Integrated Security=True;"))
                {
                    // SQL sorgusunu oluştur ve parametreleri ekle
                    string updateQuery = "UPDATE [dbo].[Users] SET [password] = @password WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@password", tbPasswordAgain.Text);
                        cmd.Parameters.AddWithValue("@username", username);

                        try
                        {
                            // Veritabanı bağlantısını aç
                            con.Open();

                            // SQL sorgusunu çalıştır ve etkilenen satır sayısını al
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Kullanıcıya işlem sonucunu bildir
                            if (rowsAffected > 0)
                            {
                                DialogResult result = MessageBox.Show("Password updated successfully!", "Information", MessageBoxButtons.OK);
                                if (result == DialogResult.OK)
                                {
                                    this.Close(); // Formu kapat
                                }
                            }
                            else
                            {
                                MessageBox.Show("Password update failed. Please check the username.", "Error", MessageBoxButtons.OK);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Hata durumunda kullanıcıya bilgi ver
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            else
            {
                // Şifreler uyuşmazsa kullanıcıya uyarı göster
                MessageBox.Show("The new passwords do not match. Please enter the same password.");
            }
        }
    }
}
