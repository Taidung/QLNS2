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
	public partial class frmRestore: DevExpress.XtraEditors.XtraForm
	{
        public frmRestore()
		{
            InitializeComponent();
		}
        SqlConnection con = new SqlConnection(@"Data Source=TAI-DUNG-3010\SQLSERVER;Initial Catalog=QLNHANSU;Persist Security Info=True;User ID=sa;Password=123456;TrustServerCertificate=True;MultipleActiveResultSets=True");
        private void frmRestore_Load(object sender, EventArgs e)
        {
            txtUrl.Enabled = false;
            btnRestore.Enabled = false;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Backup file (.bak)|*.bak";
            openFile.Title = "Khôi phục dữ liệu";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtUrl.Text = openFile.FileName;
                btnRestore.Enabled = true;
            }
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();
            try
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                string sql1 = "ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.ExecuteNonQuery();

                string sql2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='"+txtUrl.Text+"' WITH REPLACE";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.ExecuteNonQuery();

                string sql3 = "ALTER DATABASE [" + database + "] SET MULTI_USER";
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                cmd3.ExecuteNonQuery();
                con.Close();
                SplashScreenManager.CloseForm(true);
                MessageBox.Show("Khôi phục dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRestore.Enabled = false;
            }
            catch (Exception)
            {
                SplashScreenManager.CloseForm(true);
                btnRestore.Enabled = false;
                MessageBox.Show("Khôi phục dữ liệu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
    }
}