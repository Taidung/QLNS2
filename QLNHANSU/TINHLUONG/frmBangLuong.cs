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
using BusinessLayer;
using DevExpress.XtraReports.UI;
using QLNHANSU.Reposts;
using DataLayer;

namespace QLNHANSU.TINHLUONG
{
	public partial class frmBangLuong: DevExpress.XtraEditors.XtraForm
	{
        public frmBangLuong()
		{
            InitializeComponent();
		}
        BANGLUONG _bangluong;
        List<tb_BANGLUONG> _lstBangLuong;
        int _namky;
        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            _bangluong = new BANGLUONG();
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();
        }

        private void btnTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _bangluong.TinhLuongNhanVien(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
            loadData();

        }
        void loadData()
        {
            gcDanhSach.DataSource = _bangluong.getList(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstBangLuong = _bangluong.getList(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
            _namky = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text);
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptBangLuong rpt = new rptBangLuong(_lstBangLuong,_namky);
            rpt.ShowPreviewDialog();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXemBangLuong_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}