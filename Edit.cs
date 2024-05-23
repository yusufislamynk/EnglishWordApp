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
            InitializeComponent();
        }
        int userID;
        public Edit(int userID)
        {
            InitializeComponent();
            this.userID = userID;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string wordTr = tbWordTR.Text;
            string wordEn = tbWordEN.Text;
            string wordSentence = tbSentence.Text;
            string wordImage = tbPicture.Text;
            Connect.con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connect.con;
            //user id dinamik yapılacak login bu sayfaya bağlandığında yapılması lazım
            cmd.CommandText = $"insert into Word (userID,wordTR,wordEN,wordSentence,isLearning,wordImage) values ('{userID}','{wordTr}','{wordEn}','{wordSentence}','0','{wordImage}')";
            cmd.ExecuteNonQuery();
            Connect.con.Close();
            MessageBox.Show("Word added SUCCESSFULLY");
            tbWordTR.Clear();
            tbWordEN.Clear();
            tbSentence.Clear();
            tbPicture.Clear();
            pbImage.Image = null;
        }

        private void btnPictureAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pbImage.ImageLocation = openFileDialog1.FileName;
            tbPicture.Text = openFileDialog1.FileName;
            

          
        }
    }
}
