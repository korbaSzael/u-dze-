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
            this.btnSEND = new System.Windows.Forms.Button();
            this.tbFROM = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbSUBJECT = new System.Windows.Forms.TextBox();
            this.tbMESSAGE = new System.Windows.Forms.TextBox();
            this.tbTO = new System.Windows.Forms.TextBox();
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
            // btnSEND
            // 
            this.btnSEND.Location = new System.Drawing.Point(196, 75);
            this.btnSEND.Name = "btnSEND";
            this.btnSEND.Size = new System.Drawing.Size(171, 23);
            this.btnSEND.TabIndex = 98;
            this.btnSEND.Text = "SFOCIARE";
            this.btnSEND.UseVisualStyleBackColor = true;
            this.btnSEND.Click += new System.EventHandler(this.button1_Click);
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
            this.textBox5.Text = "AL CORREO";
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
            this.textBox3.Text = "AL CONTRACENA";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // tbSUBJECT
            // 
            this.tbSUBJECT.Location = new System.Drawing.Point(19, 119);
            this.tbSUBJECT.Name = "tbSUBJECT";
            this.tbSUBJECT.Size = new System.Drawing.Size(348, 20);
            this.tbSUBJECT.TabIndex = 107;
            this.tbSUBJECT.Text = "subject";
            // 
            // tbMESSAGE
            // 
            this.tbMESSAGE.Location = new System.Drawing.Point(19, 145);
            this.tbMESSAGE.Multiline = true;
            this.tbMESSAGE.Name = "tbMESSAGE";
            this.tbMESSAGE.Size = new System.Drawing.Size(348, 127);
            this.tbMESSAGE.TabIndex = 108;
            this.tbMESSAGE.Text = "message";
            // 
            // tbTO
            // 
            this.tbTO.Location = new System.Drawing.Point(19, 78);
            this.tbTO.Name = "tbTO";
            this.tbTO.Size = new System.Drawing.Size(171, 20);
            this.tbTO.TabIndex = 109;
            this.tbTO.Text = "korbazzael@gmail.com";
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 310);
            this.Controls.Add(this.tbTO);
            this.Controls.Add(this.tbMESSAGE);
            this.Controls.Add(this.tbSUBJECT);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.tbFROM);
            this.Controls.Add(this.btnSEND);
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
        private System.Windows.Forms.Button btnSEND;
        private System.Windows.Forms.TextBox tbFROM;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tbSUBJECT;
        private System.Windows.Forms.TextBox tbMESSAGE;
        private System.Windows.Forms.TextBox tbTO;
    }
}