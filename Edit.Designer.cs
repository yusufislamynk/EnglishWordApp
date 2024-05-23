namespace EnglishProject
{
    partial class Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.tbSentence = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbWordEN = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbWordTR = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tbPicture = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPictureAdd = new Guna.UI2.WinForms.Guna2Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pbImage = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.BorderRadius = 7;
            this.btnSave.BorderThickness = 4;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.Transparent;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(123, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 46);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbSentence
            // 
            this.tbSentence.BorderRadius = 7;
            this.tbSentence.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSentence.DefaultText = "";
            this.tbSentence.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSentence.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSentence.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSentence.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSentence.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSentence.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbSentence.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSentence.Location = new System.Drawing.Point(104, 177);
            this.tbSentence.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSentence.Name = "tbSentence";
            this.tbSentence.PasswordChar = '\0';
            this.tbSentence.PlaceholderText = "Sentence";
            this.tbSentence.SelectedText = "";
            this.tbSentence.Size = new System.Drawing.Size(229, 48);
            this.tbSentence.TabIndex = 1;
            // 
            // tbWordEN
            // 
            this.tbWordEN.BorderRadius = 7;
            this.tbWordEN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbWordEN.DefaultText = "";
            this.tbWordEN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbWordEN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbWordEN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbWordEN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbWordEN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbWordEN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbWordEN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbWordEN.Location = new System.Drawing.Point(104, 27);
            this.tbWordEN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbWordEN.Name = "tbWordEN";
            this.tbWordEN.PasswordChar = '\0';
            this.tbWordEN.PlaceholderText = "English Means";
            this.tbWordEN.SelectedText = "";
            this.tbWordEN.Size = new System.Drawing.Size(229, 48);
            this.tbWordEN.TabIndex = 2;
            // 
            // tbWordTR
            // 
            this.tbWordTR.BorderRadius = 7;
            this.tbWordTR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbWordTR.DefaultText = "";
            this.tbWordTR.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbWordTR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbWordTR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbWordTR.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbWordTR.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbWordTR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbWordTR.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbWordTR.Location = new System.Drawing.Point(104, 102);
            this.tbWordTR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbWordTR.Name = "tbWordTR";
            this.tbWordTR.PasswordChar = '\0';
            this.tbWordTR.PlaceholderText = "Turkish Means";
            this.tbWordTR.SelectedText = "";
            this.tbWordTR.Size = new System.Drawing.Size(229, 48);
            this.tbWordTR.TabIndex = 3;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Enabled = false;
            this.guna2PictureBox1.Image = global::EnglishProject.Properties.Resources.logo3;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(2, 2);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(71, 73);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            this.guna2PictureBox1.Visible = false;
            // 
            // tbPicture
            // 
            this.tbPicture.BorderRadius = 7;
            this.tbPicture.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPicture.DefaultText = "";
            this.tbPicture.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPicture.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPicture.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPicture.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPicture.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPicture.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbPicture.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPicture.Location = new System.Drawing.Point(104, 250);
            this.tbPicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPicture.Name = "tbPicture";
            this.tbPicture.PasswordChar = '\0';
            this.tbPicture.PlaceholderText = "Add Picture";
            this.tbPicture.SelectedText = "";
            this.tbPicture.Size = new System.Drawing.Size(169, 48);
            this.tbPicture.TabIndex = 6;
            // 
            // btnPictureAdd
            // 
            this.btnPictureAdd.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPictureAdd.BorderRadius = 7;
            this.btnPictureAdd.BorderThickness = 4;
            this.btnPictureAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPictureAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPictureAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPictureAdd.FillColor = System.Drawing.Color.Transparent;
            this.btnPictureAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPictureAdd.ForeColor = System.Drawing.Color.White;
            this.btnPictureAdd.Location = new System.Drawing.Point(279, 250);
            this.btnPictureAdd.Name = "btnPictureAdd";
            this.btnPictureAdd.Size = new System.Drawing.Size(54, 46);
            this.btnPictureAdd.TabIndex = 7;
            this.btnPictureAdd.Text = "...";
            this.btnPictureAdd.Click += new System.EventHandler(this.btnPictureAdd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pbImage
            // 
            this.pbImage.BorderRadius = 6;
            this.pbImage.ImageRotate = 0F;
            this.pbImage.Location = new System.Drawing.Point(387, 27);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(165, 125);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 8;
            this.pbImage.TabStop = false;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnPictureAdd);
            this.Controls.Add(this.tbPicture);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.tbWordTR);
            this.Controls.Add(this.tbWordEN);
            this.Controls.Add(this.tbSentence);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Edit";
            this.Text = "Edit";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox tbSentence;
        private Guna.UI2.WinForms.Guna2TextBox tbWordEN;
        private Guna.UI2.WinForms.Guna2TextBox tbWordTR;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox tbPicture;
        private Guna.UI2.WinForms.Guna2Button btnPictureAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2PictureBox pbImage;
    }
}