using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BusinessLayer.DTO;
using System.Collections.Generic;

namespace QLNHANSU.Reposts
{
	public partial class rptHopDongLaoDong : DevExpress.XtraReports.UI.XtraReport
	{	
		public rptHopDongLaoDong()
		{
			InitializeComponent();
		}
        public rptHopDongLaoDong(List<HOPDONG_DTO> lstHD)
        {
            InitializeComponent();
			this._lstHD = lstHD;
			this.DataSource = _lstHD;
			loadData();
        }
		List<HOPDONG_DTO> _lstHD;
        void loadData()
		{
			lblSoHD.DataBindings.Add("Text", _lstHD, "SOHD");
		}
    }
}
