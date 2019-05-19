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
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbPASSWORD
            // 
            this.tbPASSWORD.HideSelection = false;
            this.tbPASSWORD.Location = new System.Drawing.Point(196, 49);
            this.tbPASSWORD.Name = "tbPASSWORD";
            this.tbPASSWORD.PasswordChar = '~';
            this.tbPASSWORD.Size = new System.Drawing.Size(171, 20);
            this.tbPASSWORD.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 23);
            this.button1.TabIndex = 98;
            this.button1.Text = "WYŚLIJ SPOSÓB1";
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
            this.tbFROM.Text = "login@gmail.com";
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
            this.textBox5.Text = "LOGIN";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.AllowDrop = true;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(19, 49);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(171, 20);
            this.textBox3.TabIndex = 102;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "PASSWORD";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 23);
            this.button2.TabIndex = 103;
            this.button2.Text = "WYŚLIJ SPOSÓB2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(196, 133);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 24);
            this.button3.TabIndex = 104;
            this.button3.Text = "WYŚLIJ SPOSÓB3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(19, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(171, 20);
            this.textBox1.TabIndex = 105;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "UPUŚĆ PLIKI NA ZIP";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.Location = new System.Drawing.Point(196, 278);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(171, 20);
            this.textBox2.TabIndex = 106;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "WYŁÓŻ ZIP";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox2_DragDrop);
            this.textBox2.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 310);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox5);
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
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}