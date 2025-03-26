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
using QLNHANSU.Reposts;
using DevExpress.XtraReports.UI;
using BusinessLayer.DTO;
using System.Text.RegularExpressions;
using DevExpress.XtraRichEdit.API.Native;

namespace QLNHANSU
{
	public partial class frmHopDongLaoDong: DevExpress.XtraEditors.XtraForm
	{
        public frmHopDongLaoDong()
		{
            InitializeComponent();
		}
        HOPDONGLAODONG _hdld;
        NHANVIEN _nhanvien;
        bool _them;
        string _soHD;
        string _MaxSoHD;
        List<HOPDONG_DTO> _lstHD;

        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            _hdld = new HOPDONGLAODONG();
            _nhanvien = new NHANVIEN();
            _them = false;
            _showHide(true);
            loadData();
            loadNhanVien();
            splitContainer1.Panel1Collapsed = true;
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnPrint.Enabled = kt;
            txtSoHD.Enabled = !kt;
            dtNgayBatDau.Enabled = !kt;
            dtNgayKetThuc.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            spHeSoLuong.Enabled = !kt;
            spLanKy.Enabled = !kt;
            slkNhanVien.Enabled = !kt;


        }
        void _reset()
        {
            txtSoHD.Text = string.Empty;
            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = dtNgayBatDau.Value.AddMonths(6);
            dtNgayKy.Value = DateTime.Now;
            spLanKy.Text = "1";
            spHeSoLuong.Text = "1";
            //txtNoiDung.Text = string.Empty;
        }
        void loadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getList();
            slkNhanVien.Properties.ValueMember = "MANV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        void loadData()
        {
            gcDanhSach.DataSource = _hdld.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắn chắn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _hdld.Delete(_soHD,1);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _lstHD = _hdld.getItemFull(_soHD);
            rptHopDongLaoDong rpt = new rptHopDongLaoDong(_lstHD);
            rpt.ShowPreviewDialog();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                   //Số hđ có dạng: 00001/2025/HĐLĐ
                var maxSoHD = _hdld.MaxSoHopDong();
                int so = int.Parse(maxSoHD.Substring(0,5)) + 1;

                tb_HOPDONG hd = new tb_HOPDONG();
                hd.SOHD = so.ToString("00000") + @"/"+DateTime.Now.Year.ToString()+@"/HĐLĐ";
                hd.NGAYBATDAU = dtNgayBatDau.Value;
                hd.NGAYKETTHUC = dtNgayKetThuc.Value;
                hd.NGAYKY = dtNgayKy.Value;
                hd.THOIHAN = cboThoiHan.Text;
                hd.HESOLUONG = double.Parse(spHeSoLuong.EditValue.ToString());
                hd.LUONGCOBAN = int.Parse(spLuongCoBan.EditValue.ToString());
                hd.LANKY = int.Parse(spLanKy.EditValue.ToString());
                hd.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                hd.NOIDUNG = txtNoiDung.RtfText;
                hd.MACTY = 1;
                hd.CREATED_BY = 1;
                hd.CREATED_DATE = DateTime.Now;
                _hdld.Add(hd);
            }
            else
            {
                var hd = _hdld.getItem(_soHD);
                hd.NGAYBATDAU = dtNgayBatDau.Value;
                hd.NGAYKETTHUC = dtNgayKetThuc.Value;
                hd.NGAYKY = dtNgayKy.Value;
                hd.THOIHAN = cboThoiHan.Text;
                hd.HESOLUONG = double.Parse(spHeSoLuong.EditValue.ToString());
                hd.LUONGCOBAN = int.Parse(spLuongCoBan.EditValue.ToString());
                hd.LANKY = int.Parse(spLanKy.EditValue.ToString());
                hd.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                hd.NOIDUNG = txtNoiDung.RtfText;
                hd.MACTY = 1;
                hd.CREATED_BY = 1;
                hd.CREATED_DATE = DateTime.Now;
                _hdld.Update(hd);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soHD = gvDanhSach.GetFocusedRowCellValue("SOHD").ToString();
                var hd = _hdld.getItem(_soHD);
                txtSoHD.Text = _soHD;
                dtNgayBatDau.Value = hd.NGAYBATDAU.Value;
                dtNgayKetThuc.Value = hd.NGAYKETTHUC.Value;
                dtNgayKy.Value = hd.NGAYKY.Value;
                cboThoiHan.Text = hd.THOIHAN;
                spHeSoLuong.EditValue = hd.HESOLUONG;
                spLuongCoBan.EditValue = hd.LUONGCOBAN;
                spLanKy.Text = hd.LANKY.ToString();
                slkNhanVien.EditValue = hd.MANV;
                txtNoiDung.RtfText = hd.NOIDUNG;
                _lstHD = _hdld.getItemFull(_soHD);
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DELETED_BY" && e.CellValue != null)
            {
                Image img = Properties.Resources.del3;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

        private void spLuongCoBan_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}