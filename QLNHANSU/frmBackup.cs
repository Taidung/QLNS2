using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraSplashScreen;

namespace QLNHANSU
{
	public partial class frmBackup: DevExpress.XtraEditors.XtraForm
	{
        public frmBackup()
		{
            InitializeComponent();
		}

        private void txtUrl_EditValueChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=TAI-DUNG-3010\SQLSERVER;Initial Catalog=QLNHANSU;Persist Security Info=True;User ID=sa;Password=123456;TrustServerCertificate=True;MultipleActiveResultSets=True");

        private void frmBackup_Load(object sender, EventArgs e)
        {
            txtUrl.Enabled = false;
            btnBackup.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                txtUrl.Text = fb.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string db = con.Database.ToString();
            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn lưu file sao lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                string backupFilePath = System.IO.Path.Combine(txtUrl.Text, db + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak");
                string sql = $"BACKUP DATABASE [{db}] TO DISK = '{backupFilePath}'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                SplashScreenManager.CloseForm(true);
                MessageBox.Show("Sao lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBackup.Enabled = false;
            }
        }
    }
}