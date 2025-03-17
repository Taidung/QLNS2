﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DataLayer;
using System.Collections.Generic;

namespace QLNHANSU.Reposts
{
	public partial class rptBangLuong : DevExpress.XtraReports.UI.XtraReport
	{	
		public rptBangLuong()
		{
			InitializeComponent();
		}
		List<tb_BANGLUONG> _lst;
		int _namky;
        public rptBangLuong(List<tb_BANGLUONG> _lstBangLuong, int namky)
        {
            InitializeComponent();
			this._lst = _lstBangLuong;
			this._namky = namky;
            lblThangNam.Text = "Tháng " + _namky.ToString().Substring(4) + " năm " + _namky.ToString().Substring(0,4);
			this.DataSource = _lst;
            loadData();
        }
		void loadData()
		{
			lblMANV.DataBindings.Add("Text", DataSource, "MANV");
			lblHOTEN.DataBindings.Add("Text", DataSource, "HOTEN");
            lblNGAYCONG.DataBindings.Add("Text", DataSource, "NGAYCONGTRONGTHANG");
            lblNGAYPHEP.DataBindings.Add("Text", DataSource, "NGAYPHEP");
            lblNGAYLE.DataBindings.Add("Text", DataSource, "NGAYLE");
            lblCONGCHUNHAT.DataBindings.Add("Text", DataSource, "NGAYCHUNHAT");
            lblTANGCA.DataBindings.Add("Text", DataSource, "TANGCA");
            lblPHUCAP.DataBindings.Add("Text", DataSource, "PHUCAP");
            lblUNGLUONG.DataBindings.Add("Text", DataSource, "UNGLUONG");
            lblLUONGNGAYTHUONG.DataBindings.Add("Text", DataSource, "NGAYTHUONG");
            lblTHUCLANH.DataBindings.Add("Text", DataSource, "THUCLANH");
        }
    }
}
