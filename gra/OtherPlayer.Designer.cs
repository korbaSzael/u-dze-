namespace gra
{
    partial class OtherPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherPlayer));
            this.rtbFIND = new System.Windows.Forms.RichTextBox();
            this.tbFIND = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.ComboBox();
            this.bCreate = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.bLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbFIND
            // 
            this.rtbFIND.Location = new System.Drawing.Point(142, 136);
            this.rtbFIND.Name = "rtbFIND";
            this.rtbFIND.Size = new System.Drawing.Size(200, 128);
            this.rtbFIND.TabIndex = 6;
            this.rtbFIND.Text = "ashjdbaskjqqs;ldjjsakdqqklhqq\njksamdkljdsaqqalkjnlqq\nd,qq\n\nqq\nsa";
            // 
            // tbFIND
            // 
            this.tbFIND.Location = new System.Drawing.Point(12, 170);
            this.tbFIND.Multiline = true;
            this.tbFIND.Name = "tbFIND";
            this.tbFIND.Size = new System.Drawing.Size(124, 26);
            this.tbFIND.TabIndex = 7;
            this.tbFIND.Text = "qq";
            this.tbFIND.Click += new System.EventHandler(this.tbbFIND_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Znajdź w tekście";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.tbbFIND_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Otwórz plik rtf";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 236);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Zapisz plik rtf";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // login
            // 
            this.login.FormattingEnabled = true;
            this.login.Location = new System.Drawing.Point(12, 12);
            this.login.MaxDropDownItems = 100;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(190, 21);
            this.login.Sorted = true;
            this.login.TabIndex = 11;
            this.login.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyUp);
            // 
            // bCreate
            // 
            this.bCreate.Enabled = false;
            this.bCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bCreate.Location = new System.Drawing.Point(217, 65);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(125, 29);
            this.bCreate.TabIndex = 12;
            this.bCreate.Text = "twórz tego gracza";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.button5_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(12, 39);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '~';
            this.tbPassword.Size = new System.Drawing.Size(190, 20);
            this.tbPassword.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(217, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(125, 20);
            this.textBox4.TabIndex = 14;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "nazwa gracza";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(217, 39);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(125, 20);
            this.textBox5.TabIndex = 15;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "hasło gracza";
            // 
            // bLogin
            // 
            this.bLogin.Enabled = false;
            this.bLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bLogin.Location = new System.Drawing.Point(12, 65);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(190, 29);
            this.bLogin.TabIndex = 16;
            this.bLogin.Text = "loguj z powyższymi danymi";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Przeszukaj poniżej zapisy za hasłem...";
            // 
            // OtherPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 303);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.login);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbFIND);
            this.Controls.Add(this.rtbFIND);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OtherPlayer";
            this.Text = "OtherPlayer";
            this.Load += new System.EventHandler(this.OtherPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbFIND;
        private System.Windows.Forms.TextBox tbFIND;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox login;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Label label1;
    }
}