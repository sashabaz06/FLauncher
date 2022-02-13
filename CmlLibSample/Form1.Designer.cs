namespace CmlLibSample
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_loginOption = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Txt_Ram = new System.Windows.Forms.TextBox();
            this.Xmx_RAM = new System.Windows.Forms.Label();
            this.Btn_apply = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Txt_Email = new System.Windows.Forms.TextBox();
            this.Txt_Pw = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_loginOption);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Txt_Ram);
            this.groupBox1.Controls.Add(this.Xmx_RAM);
            this.groupBox1.Controls.Add(this.Btn_apply);
            this.groupBox1.Controls.Add(this.Path);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Btn_Login);
            this.groupBox1.Controls.Add(this.Txt_Email);
            this.groupBox1.Controls.Add(this.Txt_Pw);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 182);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CML Launcher";
            // 
            // Btn_loginOption
            // 
            this.Btn_loginOption.Location = new System.Drawing.Point(243, 112);
            this.Btn_loginOption.Name = "Btn_loginOption";
            this.Btn_loginOption.Size = new System.Drawing.Size(64, 58);
            this.Btn_loginOption.TabIndex = 15;
            this.Btn_loginOption.Text = "Login Option";
            this.Btn_loginOption.UseVisualStyleBackColor = true;
            this.Btn_loginOption.Click += new System.EventHandler(this.Btn_loginOption_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Txt_Ram
            // 
            this.Txt_Ram.Location = new System.Drawing.Point(79, 115);
            this.Txt_Ram.Name = "Txt_Ram";
            this.Txt_Ram.Size = new System.Drawing.Size(65, 20);
            this.Txt_Ram.TabIndex = 11;
            this.Txt_Ram.Text = "1024";
            // 
            // Xmx_RAM
            // 
            this.Xmx_RAM.AutoSize = true;
            this.Xmx_RAM.Location = new System.Drawing.Point(21, 118);
            this.Xmx_RAM.Name = "Xmx_RAM";
            this.Xmx_RAM.Size = new System.Drawing.Size(51, 13);
            this.Xmx_RAM.TabIndex = 10;
            this.Xmx_RAM.Text = "Xmx(M) : ";
            // 
            // Btn_apply
            // 
            this.Btn_apply.Location = new System.Drawing.Point(243, 22);
            this.Btn_apply.Name = "Btn_apply";
            this.Btn_apply.Size = new System.Drawing.Size(64, 25);
            this.Btn_apply.TabIndex = 9;
            this.Btn_apply.Text = "apply";
            this.Btn_apply.UseVisualStyleBackColor = true;
            this.Btn_apply.Click += new System.EventHandler(this.Btn_apply_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(79, 24);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(157, 20);
            this.Path.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Path : ";
            // 
            // Btn_Login
            // 
            this.Btn_Login.Location = new System.Drawing.Point(243, 53);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(64, 53);
            this.Btn_Login.TabIndex = 6;
            this.Btn_Login.Text = "Login";
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Txt_Email
            // 
            this.Txt_Email.Location = new System.Drawing.Point(79, 54);
            this.Txt_Email.Name = "Txt_Email";
            this.Txt_Email.Size = new System.Drawing.Size(157, 20);
            this.Txt_Email.TabIndex = 5;
            // 
            // Txt_Pw
            // 
            this.Txt_Pw.Location = new System.Drawing.Point(79, 83);
            this.Txt_Pw.Name = "Txt_Pw";
            this.Txt_Pw.Size = new System.Drawing.Size(157, 20);
            this.Txt_Pw.TabIndex = 5;
            this.Txt_Pw.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 222);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_Ram;
        private System.Windows.Forms.Label Xmx_RAM;
        private System.Windows.Forms.Button Btn_apply;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.TextBox Txt_Email;
        private System.Windows.Forms.TextBox Txt_Pw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_loginOption;
    }
}