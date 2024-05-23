using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Org.BouncyCastle.Bcpg;

namespace EnglishProject
{
    public partial class zart : Form
    {
        bool isAnimation = true;
        const int MAX_WIDTH = 559;
        const int MIN_WIDTH = 80;
        Timer animationTimer = new Timer();
        int movedepth = 13;
        Timer animationTimer2 = new Timer();
        bool isAnimation2 = false;
        Task t1;
        public zart()
        {
            InitializeComponent();
            animationTimer.Interval = 20;
            animationTimer.Tick += KaydirmaPanelAnimation_Tick;
            animationTimer2.Tick += KaydirmaPanelAnimation2_Tick;
            animationTimer2.Interval = 20;
            hidePasswordPicture.Location = showPasswordPicture.Location;
            LoginPanel.Controls.Add(hidePasswordPicture);
            LoginPanel.Controls.Add(showPasswordPicture);
            showPasswordPicture.Visible = false;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            int userID = 0;

            if (emailLoginTxt.Text == "" || passwordLoginTxt.Text == "")
            {
                MessageBox.Show("please fill in the blank fields");
            }
            else
            {
                Connect.con.Open();
                string query = $"select * from Users where email = '{emailLoginTxt.Text.ToString()}' and password = '{passwordLoginTxt.Text.ToString()}'";
                SqlCommand cmd = new SqlCommand(query, Connect.con);
                SqlDataReader reader = cmd.ExecuteReader();
                // Kelimeleri saklamak için bir liste oluştur
                if (reader.Read())
                {
                    userID = Convert.ToInt32(reader["userID"]);
                    reader.Close();
                    Connect.con.Close();
                    Main main = new Main(userID);
                    main.Show();
                    this.Hide();

                }
                else
                {
                    Connect.con.Close();
                    MessageBox.Show("You have logged in incorrectly.Please try again!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
               
            }
        }
        private void KaydirmaPanelAnimation_Tick(object sender, EventArgs e)
        {
            if (KaydirmaPanel.Height >= MIN_WIDTH)
            {
                KaydirmaPanel.Height -= movedepth;

            }
            else
            {
                KaydirmaPanel.Height = MIN_WIDTH;
                animationTimer.Stop();
                isAnimation2 = false;
            }

        }
        private void KaydirmaPanelAnimation2_Tick(object sender, EventArgs e)
        {
            if (KaydirmaPanel.Height <= MAX_WIDTH)
            {
                KaydirmaPanel.Height += movedepth;
            }
            else
            {
                KaydirmaPanel.Height = MAX_WIDTH;
                animationTimer2.Stop();
                isAnimation = false;
            }
        }
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            if (isAnimation2)
            {
                return;
            }
            animationTimer2.Start();
            isAnimation2 = true;
            SignUpButton.Visible = false;
            btnBack.Visible = true;
            btnBack.Enabled = true;
            LoginButton.Visible = false;
            LoginButton.Enabled = false;
        }

        private void zart_Load(object sender, EventArgs e)
        {
            KaydirmaPanel.Location = new Point(0, 472);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (isAnimation)
            {
                return;
            }
            isAnimation = true;
            animationTimer.Start();
            SignUpButton.Visible = true;
            LoginButton.Visible = true;
            LoginButton.Enabled = true;
            btnBack.Visible = false;
            btnBack.Enabled = false;
        }

        private void signUp2Button_Click(object sender, EventArgs e)
        {
            if (emailRegisterTxt.Text  != "" ) { 

            int userID = 0;
            if (Connect.con.State == ConnectionState.Closed)
            {
                Connect.con.Open();
            }

            string query = $"select userID from Users where email = '{emailRegisterTxt.Text.ToString()}'";
            SqlCommand cmd = new SqlCommand(query, Connect.con);
            SqlDataReader reader = cmd.ExecuteReader();
            // Kelimeleri saklamak için bir liste oluştur
            if (reader.Read())
            {
                //Bu email kayıtlı zaten hata
                userID = Convert.ToInt32(reader["userID"]);
                reader.Close();

                MessageBox.Show("This email is already exist. Please enter a different email!");
                emailRegisterTxt.Clear();
                emailRegisterTxt.Focus();
            }
            else
            {
                reader.Close(); // SqlDataReader'ı burada kapat

                //Email yok bu yüzden kayıt yap
                string username = userNameTxt.Text;
                string name = nameTxt.Text;
                string surname = nameSurname.Text;
                string email = emailRegisterTxt.Text;
                string password = passwordRegisterTxt.Text;
                string confirmpass = ConfirmPasswordTxt.Text;
                if (password == confirmpass)
                {
                    if (Connect.con.State == ConnectionState.Closed)
                    {
                        Connect.con.Open();
                    }
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = Connect.con;
                    //user id dinamik yapılacak login bu sayfaya bağlandığında yapılması lazım
                    cmd2.CommandText = $"insert into Users (name,surname,username,email,password) values ('{name}','{surname}','{username}','{email}','{password}')";
                    cmd2.ExecuteNonQuery();
                    Connect.con.Close();
                    MessageBox.Show("\"User is created! You're redirecting to Login Page... ", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (isAnimation)
                    {
                        return;
                    }
                    isAnimation = true;
                    animationTimer.Start();
                    SignUpButton.Visible = true;
                    LoginButton.Visible = true;
                    LoginButton.Enabled = true;
                    btnBack.Visible = false;
                    btnBack.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Passwords are not matched!");
                    passwordRegisterTxt.Clear();
                    ConfirmPasswordTxt.Clear();
                    passwordRegisterTxt.Focus();
                }
            }
        }
            else//fieldlar boş mu kontrolü eğer boşsa buraya girecek
            {
                MessageBox.Show("\"Please fill all of fields!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void ForgotTextBox_Click(object sender, EventArgs e)
        {
            
           Fp fp = new Fp();
           fp.ShowDialog();
           
        }
    }
}
