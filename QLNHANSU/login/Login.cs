using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using BusinessLayer;

namespace QLNHANSU.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
            try
            {
                using (MemoryStream ms = new MemoryStream(global::QLNHANSU.Properties.Resources.logo))
                {
                    this.pictureBoxLogoLeft.Image = Image.FromStream(ms);
                    this.pictureBoxLogoRight.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message);
            }
        }
        USER _user;
        private void Login_Load(object sender, EventArgs e)
        {
        }
        
        // Sự kiện checkbox SHOW PASSWORD
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            String username = textBoxEmail.Text;
            String password = textBoxPassword.Text;
            _user = new USER();

            if (_user.ValidateUser(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide(); // Ẩn form Login thay vì đóng nó

                MainForm mainWindow = new MainForm();
                mainWindow.ShowDialog(); // Hiển thị MainForm

                this.Show(); // Hiển thị lại Login nếu cần (nếu MainForm bị đóng)
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Sự kiện nút LOGIN (thay bằng logic đăng nhập của bạn)
        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    // Ví dụ: Kiểm tra đăng nhập
        //    //MessageBox.Show("Đăng nhập với Username: " + txtUsername.Text + " và Password: " + txtPassword.Text);

        //}

        // Sự kiện nút CLEAR
        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtUsername.Clear();
            //txtPassword.Clear();
            //chkShowPassword.Checked = false;
        }

        // Sự kiện liên kết CREATE ACCOUNT
        private void lblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Thêm logic để mở form đăng ký hoặc điều hướng
            MessageBox.Show("Chuyển hướng đến form tạo tài khoản!");
        }

        

        private void labelWelcomeZad_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            
        }
    }
}