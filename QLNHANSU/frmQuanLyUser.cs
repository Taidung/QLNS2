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
using DataLayer;

namespace QLNHANSU
{
	public partial class frmQuanLyUser: DevExpress.XtraEditors.XtraForm
	{
        public frmQuanLyUser()
		{
            InitializeComponent();
		}
        USER _user;
        bool _them;
        int _id;
        private void frmQuanLyUser_Load(object sender, EventArgs e)
        {
            _them = false;
            _user = new USER();
            _showHide(true);
            loadData();
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            txtTen.Enabled = !kt;
            txtPassword.Enabled = !kt;
            txtPhanQuyen.Enabled = !kt;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _user.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txtTen.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPhanQuyen.Text = string.Empty;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắn chắn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _user.Delete(_id);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                tb_Users user = new tb_Users();
                user.username = txtTen.Text;
                user.password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
                user.role = txtPhanQuyen.Text;
                _user.Add(user);
            }
            else
            {
                var user = _user.getItem(_id);
                user.username = txtTen.Text;
                //user.password = txtPassword.Text;
                user.password = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);
                user.role = txtPhanQuyen.Text;
                _user.Update(user);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("id").ToString());
            txtTen.Text = gvDanhSach.GetFocusedRowCellValue("username").ToString();
            txtPassword.Text = gvDanhSach.GetFocusedRowCellValue("password").ToString();
            txtPhanQuyen.Text = gvDanhSach.GetFocusedRowCellValue("role").ToString();
        }
    }
}