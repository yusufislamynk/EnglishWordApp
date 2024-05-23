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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbName.Text;
            Connect.con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.con;
            // cmd.CommandText = "insert into Users (name,surname,username,email,password) values ('name','surname','username','email','Password')";
            cmd.CommandText = $"select Count(*) as 'Count' from Users where username = '{username}' and password ='test'";
            int count = (int)cmd.ExecuteScalar();

            if (count==0) 
            {
                label1.Text = "Başarıyla giriş yapıldı";
            }
            else
            {
                label1.Text = "Giriş yapıldı";
            }
            Connect.con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
