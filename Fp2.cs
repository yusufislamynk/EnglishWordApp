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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Guna.UI2.WinForms;

namespace EnglishProject
{
    public partial class Fp2 : Form
    {
        string username = Fp.to;
        public Fp2()
        {
            InitializeComponent();
        }

        private void Fp2_Load(object sender, EventArgs e)
        {

        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbPasswordAgain.Text)
            {
                
                SqlConnection con = new SqlConnection("Data Source=YUSUFISLAMYANıK\\SQLEXPRESS;Initial Catalog=EnglishProject;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Users] SET [password] = '" + tbPasswordAgain.Text + "' WHERE username='" + username + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DialogResult result = MessageBox.Show("Tamam", "Uyarı", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("the new password do not match so enter same password");
            }
            
        }
    }
}
