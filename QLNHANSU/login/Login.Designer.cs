using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLNHANSU.Login
{
    public partial class Login : Form
    {
        //public Login()
        //{
        //    InitializeComponent();
        //}

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelWelcomeZad = new System.Windows.Forms.Label();
            this.pictureBoxLogoLeft = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.linkLabelForgotPassword = new System.Windows.Forms.LinkLabel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelSignIn = new System.Windows.Forms.Label();
            this.labelWelcomeBack = new System.Windows.Forms.Label();
            this.pictureBoxLogoRight = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoLeft)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoRight)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Purple;
            this.panelLeft.Controls.Add(this.labelWelcomeZad);
            this.panelLeft.Controls.Add(this.pictureBoxLogoLeft);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(234, 400);
            this.panelLeft.TabIndex = 0;
            // 
            // labelWelcomeZad
            // 
            this.labelWelcomeZad.AutoSize = true;
            this.labelWelcomeZad.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelWelcomeZad.ForeColor = System.Drawing.Color.White;
            this.labelWelcomeZad.Location = new System.Drawing.Point(16, 205);
            this.labelWelcomeZad.Name = "labelWelcomeZad";
            this.labelWelcomeZad.Size = new System.Drawing.Size(202, 22);
            this.labelWelcomeZad.TabIndex = 1;
            this.labelWelcomeZad.Text = "WELCOME TO QLNS";
            this.labelWelcomeZad.Click += new System.EventHandler(this.labelWelcomeZad_Click);
            // 
            // pictureBoxLogoLeft
            // 
            this.pictureBoxLogoLeft.Location = new System.Drawing.Point(67, 80);
            this.pictureBoxLogoLeft.Name = "pictureBoxLogoLeft";
            this.pictureBoxLogoLeft.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxLogoLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogoLeft.TabIndex = 0;
            this.pictureBoxLogoLeft.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.buttonLogin);
            this.panelRight.Controls.Add(this.linkLabelForgotPassword);
            this.panelRight.Controls.Add(this.textBoxPassword);
            this.panelRight.Controls.Add(this.labelPassword);
            this.panelRight.Controls.Add(this.textBoxEmail);
            this.panelRight.Controls.Add(this.labelEmail);
            this.panelRight.Controls.Add(this.labelSignIn);
            this.panelRight.Controls.Add(this.labelWelcomeBack);
            this.panelRight.Controls.Add(this.pictureBoxLogoRight);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(234, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(366, 400);
            this.panelRight.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Purple;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(50, 288);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(250, 40);
            this.buttonLogin.TabIndex = 9;
            this.buttonLogin.Text = "LOGIN";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // linkLabelForgotPassword
            // 
            this.linkLabelForgotPassword.AutoSize = true;
            this.linkLabelForgotPassword.Font = new System.Drawing.Font("Arial", 9F);
            this.linkLabelForgotPassword.LinkColor = System.Drawing.Color.Purple;
            this.linkLabelForgotPassword.Location = new System.Drawing.Point(200, 270);
            this.linkLabelForgotPassword.Name = "linkLabelForgotPassword";
            this.linkLabelForgotPassword.Size = new System.Drawing.Size(0, 15);
            this.linkLabelForgotPassword.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Location = new System.Drawing.Point(50, 230);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(250, 20);
            this.textBoxPassword.TabIndex = 6;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.Gray;
            this.labelPassword.Location = new System.Drawing.Point(47, 209);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(82, 18);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Location = new System.Drawing.Point(50, 170);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(250, 20);
            this.textBoxEmail.TabIndex = 4;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.Gray;
            this.labelEmail.Location = new System.Drawing.Point(47, 149);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(84, 18);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "Username:";
            // 
            // labelSignIn
            // 
            this.labelSignIn.AutoSize = true;
            this.labelSignIn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSignIn.ForeColor = System.Drawing.Color.DimGray;
            this.labelSignIn.Location = new System.Drawing.Point(46, 112);
            this.labelSignIn.Name = "labelSignIn";
            this.labelSignIn.Size = new System.Drawing.Size(152, 19);
            this.labelSignIn.TabIndex = 2;
            this.labelSignIn.Text = "Sign in to continue";
            // 
            // labelWelcomeBack
            // 
            this.labelWelcomeBack.AutoSize = true;
            this.labelWelcomeBack.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.labelWelcomeBack.ForeColor = System.Drawing.Color.Black;
            this.labelWelcomeBack.Location = new System.Drawing.Point(44, 80);
            this.labelWelcomeBack.Name = "labelWelcomeBack";
            this.labelWelcomeBack.Size = new System.Drawing.Size(216, 32);
            this.labelWelcomeBack.TabIndex = 1;
            this.labelWelcomeBack.Text = "Welcome Back,";
            // 
            // pictureBoxLogoRight
            // 
            this.pictureBoxLogoRight.Location = new System.Drawing.Point(50, 20);
            this.pictureBoxLogoRight.Name = "pictureBoxLogoRight";
            this.pictureBoxLogoRight.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogoRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogoRight.TabIndex = 0;
            this.pictureBoxLogoRight.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoLeft)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogoRight)).EndInit();
            this.ResumeLayout(false);

        }

        private void pictureBoxEye_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
        }

        //private void buttonLogin_Click(object sender, EventArgs e)
        //{
        //    string email = textBoxEmail.Text;
        //    string password = textBoxPassword.Text;
        //    // Thêm logic kiểm tra đăng nhập ở đây
        //    MessageBox.Show($"Email: {email}, Password: {password}");
        //}

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox pictureBoxLogoLeft;
        private System.Windows.Forms.Label labelWelcomeZad;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox pictureBoxLogoRight;
        private System.Windows.Forms.Label labelWelcomeBack;
        private System.Windows.Forms.Label labelSignIn;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.LinkLabel linkLabelForgotPassword;
        private System.Windows.Forms.Button buttonLogin;
    }
}