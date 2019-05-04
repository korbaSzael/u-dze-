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
            this.button1 = new System.Windows.Forms.Button();
            this.tbDECRYPTED = new System.Windows.Forms.TextBox();
            this.tbENCRYPTED = new System.Windows.Forms.TextBox();
            this.tbDATA = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rtbFIND = new System.Windows.Forms.RichTextBox();
            this.tbFIND = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "szyfruj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbDECRYPTED
            // 
            this.tbDECRYPTED.Location = new System.Drawing.Point(159, 232);
            this.tbDECRYPTED.Multiline = true;
            this.tbDECRYPTED.Name = "tbDECRYPTED";
            this.tbDECRYPTED.Size = new System.Drawing.Size(183, 71);
            this.tbDECRYPTED.TabIndex = 1;
            // 
            // tbENCRYPTED
            // 
            this.tbENCRYPTED.Location = new System.Drawing.Point(159, 143);
            this.tbENCRYPTED.Multiline = true;
            this.tbENCRYPTED.Name = "tbENCRYPTED";
            this.tbENCRYPTED.Size = new System.Drawing.Size(183, 71);
            this.tbENCRYPTED.TabIndex = 2;
            // 
            // tbDATA
            // 
            this.tbDATA.Location = new System.Drawing.Point(159, 57);
            this.tbDATA.Multiline = true;
            this.tbDATA.Name = "tbDATA";
            this.tbDATA.Size = new System.Drawing.Size(183, 71);
            this.tbDATA.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(29, 143);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(124, 71);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Zaszyfrowany";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(29, 232);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(124, 71);
            this.textBox2.TabIndex = 5;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Rozszyfrowany";
            // 
            // rtbFIND
            // 
            this.rtbFIND.Location = new System.Drawing.Point(159, 318);
            this.rtbFIND.Name = "rtbFIND";
            this.rtbFIND.Size = new System.Drawing.Size(183, 128);
            this.rtbFIND.TabIndex = 6;
            this.rtbFIND.Text = "ashjdbaskjqqs;ldjjsakdqqklhqq\njksamdkljdsaqqalkjnlqq\nd,qq\n\nqq\nsa";
            // 
            // tbFIND
            // 
            this.tbFIND.Location = new System.Drawing.Point(29, 420);
            this.tbFIND.Multiline = true;
            this.tbFIND.Name = "tbFIND";
            this.tbFIND.Size = new System.Drawing.Size(124, 26);
            this.tbFIND.TabIndex = 7;
            this.tbFIND.Text = "qq";
            this.tbFIND.Click += new System.EventHandler(this.tbbFIND_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Znajdź";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.tbbFIND_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Otwórz";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(29, 386);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Zapisz";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // OtherPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(790, 493);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbFIND);
            this.Controls.Add(this.rtbFIND);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbDATA);
            this.Controls.Add(this.tbENCRYPTED);
            this.Controls.Add(this.tbDECRYPTED);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OtherPlayer";
            this.Text = "OtherPlayer";
            this.Load += new System.EventHandler(this.OtherPlayer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbDECRYPTED;
        private System.Windows.Forms.TextBox tbENCRYPTED;
        private System.Windows.Forms.TextBox tbDATA;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox rtbFIND;
        private System.Windows.Forms.TextBox tbFIND;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}