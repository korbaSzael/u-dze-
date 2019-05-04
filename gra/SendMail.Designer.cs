namespace gra
{
    partial class SendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMail));
            this.tbPASSWORD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbFROM = new System.Windows.Forms.TextBox();
            this.tbSUBJECT = new System.Windows.Forms.TextBox();
            this.tbTO = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.rtbBODY = new System.Windows.Forms.RichTextBox();
            this.cbSMTP = new System.Windows.Forms.ComboBox();
            this.tbSMTP = new System.Windows.Forms.TextBox();
            this.tbUSERNAME = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbPASSWORD
            // 
            this.tbPASSWORD.HideSelection = false;
            this.tbPASSWORD.Location = new System.Drawing.Point(196, 211);
            this.tbPASSWORD.Name = "tbPASSWORD";
            this.tbPASSWORD.PasswordChar = '~';
            this.tbPASSWORD.Size = new System.Drawing.Size(171, 20);
            this.tbPASSWORD.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 98;
            this.button1.Text = "SFOCIARE AL CORREO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbFROM
            // 
            this.tbFROM.HideSelection = false;
            this.tbFROM.Location = new System.Drawing.Point(196, 23);
            this.tbFROM.Name = "tbFROM";
            this.tbFROM.Size = new System.Drawing.Size(171, 20);
            this.tbFROM.TabIndex = 1;
            this.tbFROM.Text = "@gmail.com";
            // 
            // tbSUBJECT
            // 
            this.tbSUBJECT.HideSelection = false;
            this.tbSUBJECT.Location = new System.Drawing.Point(196, 98);
            this.tbSUBJECT.Name = "tbSUBJECT";
            this.tbSUBJECT.Size = new System.Drawing.Size(171, 20);
            this.tbSUBJECT.TabIndex = 3;
            this.tbSUBJECT.Text = "qq";
            // 
            // tbTO
            // 
            this.tbTO.HideSelection = false;
            this.tbTO.Location = new System.Drawing.Point(196, 60);
            this.tbTO.Name = "tbTO";
            this.tbTO.Size = new System.Drawing.Size(171, 20);
            this.tbTO.TabIndex = 2;
            this.tbTO.Text = "@o2.pl";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(19, 23);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(171, 20);
            this.textBox5.TabIndex = 5;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "FROM";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(19, 60);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(171, 20);
            this.textBox6.TabIndex = 6;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "TO";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(19, 98);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(171, 20);
            this.textBox7.TabIndex = 7;
            this.textBox7.TabStop = false;
            this.textBox7.Text = "SUBJECT";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // rtbBODY
            // 
            this.rtbBODY.Location = new System.Drawing.Point(389, 23);
            this.rtbBODY.Name = "rtbBODY";
            this.rtbBODY.Size = new System.Drawing.Size(223, 208);
            this.rtbBODY.TabIndex = 0;
            this.rtbBODY.Text = "hhh";
            // 
            // cbSMTP
            // 
            this.cbSMTP.FormattingEnabled = true;
            this.cbSMTP.Location = new System.Drawing.Point(196, 133);
            this.cbSMTP.Name = "cbSMTP";
            this.cbSMTP.Size = new System.Drawing.Size(171, 21);
            this.cbSMTP.TabIndex = 4;
            // 
            // tbSMTP
            // 
            this.tbSMTP.Enabled = false;
            this.tbSMTP.Location = new System.Drawing.Point(19, 134);
            this.tbSMTP.Name = "tbSMTP";
            this.tbSMTP.ReadOnly = true;
            this.tbSMTP.Size = new System.Drawing.Size(171, 20);
            this.tbSMTP.TabIndex = 100;
            this.tbSMTP.TabStop = false;
            this.tbSMTP.Text = "SMTP";
            this.tbSMTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbUSERNAME
            // 
            this.tbUSERNAME.HideSelection = false;
            this.tbUSERNAME.Location = new System.Drawing.Point(196, 170);
            this.tbUSERNAME.Name = "tbUSERNAME";
            this.tbUSERNAME.Size = new System.Drawing.Size(171, 20);
            this.tbUSERNAME.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(19, 170);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(171, 20);
            this.textBox2.TabIndex = 101;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "username";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(19, 211);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(171, 20);
            this.textBox3.TabIndex = 102;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "password";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 23);
            this.button2.TabIndex = 103;
            this.button2.Text = "sposób drugi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(196, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 24);
            this.button3.TabIndex = 104;
            this.button3.Text = "sposób trzeci";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tbUSERNAME);
            this.Controls.Add(this.tbSMTP);
            this.Controls.Add(this.cbSMTP);
            this.Controls.Add(this.rtbBODY);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.tbTO);
            this.Controls.Add(this.tbSUBJECT);
            this.Controls.Add(this.tbFROM);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPASSWORD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendMail";
            this.Text = "SendMail";
            this.Load += new System.EventHandler(this.SendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPASSWORD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbFROM;
        private System.Windows.Forms.TextBox tbSUBJECT;
        private System.Windows.Forms.TextBox tbTO;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.RichTextBox rtbBODY;
        private System.Windows.Forms.ComboBox cbSMTP;
        private System.Windows.Forms.TextBox tbSMTP;
        private System.Windows.Forms.TextBox tbUSERNAME;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}