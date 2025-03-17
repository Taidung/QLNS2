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
using DataLayer;
using BusinessLayer;
using DevExpress.XtraReports.UI;

namespace QLNHANSU.Reposts
{
	public partial class frmBangCongCT: DevExpress.XtraEditors.XtraForm
	{
        public frmBangCongCT()
		{
            InitializeComponent();
		}
        NHANVIEN _nhanvien;
        BANGCONG_NV_CT _bcct_nv;
        private void frmBangCongCT_Load(object sender, EventArgs e)
        {
            _nhanvien = new NHANVIEN();
            _bcct_nv = new BANGCONG_NV_CT();
            loadNhanVien();
            cboKyCong.SelectedIndex = DateTime.Now.Month-1;
        }
        void loadNhanVien()
        {
            cboNhanVien.DataSource = _nhanvien.getList();
            cboNhanVien.DisplayMember = "HOTEN";
            cboNhanVien.ValueMember = "MANV";
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            var lst = _bcct_nv.getBangCongCT(DateTime.Now.Year * 100 + int.Parse(cboKyCong.Text), int.Parse(cboNhanVien.SelectedValue.ToString()));
            frmBangCongCTNV frp = new frmBangCongCTNV(lst);
            frp.ShowPreviewDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}