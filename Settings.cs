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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        public int userID;
        public Settings(int userId)
        {
                this.userID = userId;
                InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            Connect.con.Open();
            string query = $"select questionCount from Users where userID = {userID}";

            // SqlCommand ile sorguyu çalıştır ve sonuçları oku
            SqlCommand cmd = new SqlCommand(query, Connect.con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tbQuestionCount.Text = reader["questionCount"].ToString();
            }
                reader.Close();

            Connect.con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)

        // ayarlar butonu içerisinde seçilen kelime sayısını getiriyor
        {
            Connect.con.Open();
            string updateQuery = $"UPDATE Users SET questionCount = {Convert.ToInt32(tbQuestionCount.Text)} WHERE userID = {userID}";

            // SqlCommand ile güncelleme sorgusunu çalıştır
            SqlCommand updateCmd = new SqlCommand(updateQuery, Connect.con);
            int rowsAffected = updateCmd.ExecuteNonQuery();
            Connect.con.Close();

            MessageBox.Show("Question count successfully updated!", "Information");
            /*
            // Başka bir forma yönlendir
            Main mainForm = new Main(userID);
            mainForm.Show();
            this.Hide();
            */
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Başka bir forma yönlendir
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide();
        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }
    }
}
