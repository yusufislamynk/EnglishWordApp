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
        string randomCode;
        public static string to;
        SqlConnection conn = new SqlConnection(@"Data Source=YUSUFISLAMYANıK\SQLEXPRESS;Initial Catalog=EnglishProject;Integrated Security=True;Encrypt=True");
        public Fp()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (tbEmail.Text).ToString();
            from = "yazilimyapimiprojesi@gmail.com";
            pass = "kysu zoyf bojj gdnj";
            messageBody = "your reset code is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try 
            {
                Connect.con.Open();
                string query = "SELECT * FROM EnglishProject WHERE email = @email";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@email", email);
                smtp.Send(message);
                MessageBox.Show("code send successfully");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            if (randomCode == (tbCode.Text).ToString())
            {
                to = tbEmail.Text;
                
                Fp2 rp = new Fp2();
                rp.ShowDialog();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("wrong code");
            }
        }
    }
}
