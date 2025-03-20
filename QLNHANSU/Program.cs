using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace QLNHANSU {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new QLNHANSU.Login.Login())
            {
                // Hiển thị form login dưới dạng Dialog
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Chỉ chạy MainForm khi đăng nhập thành công
                    Application.Run(new MainForm());
                }
            }
        }

    }
}
