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
            // OtherPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}