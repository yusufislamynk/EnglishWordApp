using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace EnglishProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        int userID;
        public Main(int userID)
        {
            InitializeComponent();
            this.userID = userID;

        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            // ayarlar formunu main formundai panele getir
            panel2.Controls.Clear();
            Settings frm1 = new Settings(userID);
            frm1.TopLevel = false;
            panel2.Controls.Add(frm1);
            frm1.Show();
        }

        private void btnNewWord_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Edit frm = new Edit(userID);
            frm.TopLevel = false;
            panel2.Controls.Add(frm);
            frm.Show();
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Exam frm = new Exam(userID);
            frm.TopLevel = false;
            panel2.Controls.Add(frm);
            frm.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }
    }
}
