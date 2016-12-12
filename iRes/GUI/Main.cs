using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Title.Config;
using Title.GUI;

namespace iRes
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Configuration config = new Configuration();

        UtcQuanLyNhanVien utcQuanLyNhanVien = new UtcQuanLyNhanVien();
        UtcQuanLyKhachHang utcQuanLyKhachHang = new UtcQuanLyKhachHang();
        UtcQuanLyMonAn utcQuanLyMonAn = new UtcQuanLyMonAn();
        UctQuanLyNhomMon uctQuanLyNhomMon = new UctQuanLyNhomMon();
        UctGoiMonTheoBan uctGoiMonTheoBan = new UctGoiMonTheoBan();
        UctNhapHang uctNhapHang = new UctNhapHang();
        UctThongKe uctThongKe = new UctThongKe();
        UctQuanLyNguyenLieu uctQuanLyNguyenLieu = new UctQuanLyNguyenLieu();

        private string currentTabName;

        private void tclItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e) { }

        private void navBarItemNhanVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            utcQuanLyNhanVien.LoadData();
            utcQuanLyNhanVien.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(utcQuanLyNhanVien);
            this.currentTabName = config.TAB_NHAN_VIEN;
        }

        private void navBarItemKhachHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            utcQuanLyKhachHang.LoadData();
            utcQuanLyKhachHang.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(utcQuanLyKhachHang);
            this.currentTabName = config.TAB_KHACH_HANG;
        }

        private void navBarItemMonAn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            utcQuanLyMonAn.LoadData();
            DisableButton();
            this.barButtonDelete.Enabled = false;
            utcQuanLyMonAn.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(utcQuanLyMonAn);
            this.currentTabName = config.TAB_MON_AN;
        }

        private void navBarItemNhomMon_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctQuanLyNhomMon.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(uctQuanLyNhomMon);
            this.currentTabName = config.TAB_NHOM_MON;
        }

        private void navBarGoiMonTheoBan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctGoiMonTheoBan.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(uctGoiMonTheoBan);
            this.currentTabName = config.TAB_GOI_MON_THEO_BAN;
        }

        private void navBarNhapHangMoi_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctNhapHang.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(uctNhapHang);
            this.currentTabName = config.TAB_NHAP_HANG;
        }

        private void navBarDoanhThu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctThongKe.LoadData();
            uctThongKe.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(uctThongKe);
            this.currentTabName = config.TAB_NHAP_HANG;
        }

        /// <summary>
        /// Khoa va mo phan barButton Them, Sua, Xoa khi Click va khi chua Click
        /// </summary>
        public void DisableButtonBar()
        {
            this.barButtonAdd.Enabled = false;
            this.barButtonEdit.Enabled = false;
            this.barButtonDelete.Enabled = false;
        }

        /// <summary>
        /// Khoa va mo phan barButton Them, Sua, Xoa khi Click va khi chua Click
        /// </summary>
        public void EnableButtonBar()
        {
            this.barButtonAdd.Enabled = true;
            this.barButtonEdit.Enabled = true;
            this.barButtonDelete.Enabled = true;
        }

        /// <summary>
        /// Khoa va mo phan barButton Save va Cancel khi chua Click cac button Them, Sua, Xoa va khi chua Click
        /// </summary>
        public void DisableButton()
        {
            this.barButtonCancel.Enabled = false;
            this.barButtonSave.Enabled = false;
        }


        /// <summary>
        /// Khoa va mo phan barButton Save va Cancel khi chua Click cac button Them, Sua, Xoa va khi chua Click
        /// </summary>
        public void EnableButton()
        {
            this.barButtonCancel.Enabled = true;
            this.barButtonSave.Enabled = true;
        }



        private void barButtonEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EnableButton();
            DisableButtonBar();
            switch (this.currentTabName)
            {
                case "TabNhanVien":
                    utcQuanLyNhanVien.Edit();
                    break;
                case "TabKhachHang":
                    utcQuanLyKhachHang.Edit();
                    break;
                case "TabMonAn":
                    FrmEditMonAn frmEditMonAN = new FrmEditMonAn();
                    frmEditMonAN.ShowDialog();
                    EnableButtonBar();
                    break;
                case "TabNhomMon":
                    uctQuanLyNhomMon.Edit();
                    break;
                case "TabNguyenLieu":
                    uctQuanLyNguyenLieu.Edit();
                    break;
            }
        }

        private void barButtonDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (this.currentTabName)
            {
                case "TabNhanVien":
                    utcQuanLyNhanVien.Delete();
                    break;
                case "TabKhachHang":
                    utcQuanLyKhachHang.Delete();
                    break;
                case "TabNhomMon":
                    uctQuanLyNhomMon.Delete();
                    break;
                case "TabNguyenLieu":
                    uctQuanLyNguyenLieu.Delete();
                    break;
            }
        }

        private void barButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DisableButtonBar();
            EnableButton();
            switch (this.currentTabName)
            {
                case "TabNhanVien":
                    utcQuanLyNhanVien.Add();
                    break;
                case "TabKhachHang":
                    utcQuanLyKhachHang.Add();
                    break;
                case "TabMonAn":
                    FrmThemMonAn frmThemMonAn = new FrmThemMonAn();
                    frmThemMonAn.ShowDialog();
                    utcQuanLyMonAn.LoadData();
                    EnableButtonBar();
                    break;
                case "TabNhomMon":
                    uctQuanLyNhomMon.Add();
                    break;
                case "TabNguyenLieu":
                    uctQuanLyNguyenLieu.Add();
                    break;
            }
        }

        private void barButtonSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (this.currentTabName)
            {
                case "TabNhanVien":
                    utcQuanLyNhanVien.Save();
                    break;
                case "TabKhachHang":
                    utcQuanLyKhachHang.Save();
                    break;
                case "TabNhomMon":
                    uctQuanLyNhomMon.Save();
                    break;
                case "TabNguyenLieu":
                    uctQuanLyNguyenLieu.Save();
                    break;
            }
            EnableButtonBar();
            DisableButton();
        }

        private void barButtonCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            uctQuanLyNguyenLieu.Cancel();
            uctQuanLyNhomMon.Cancel();
            utcQuanLyKhachHang.Cancel();
            utcQuanLyNhanVien.Cancel();
            EnableButtonBar();
            DisableButton();
        }

        private void navBarItemNguyenLieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            uctQuanLyNguyenLieu.LoadData();
            uctQuanLyNguyenLieu.Dock = DockStyle.Fill;
            this.groupControlClientArea.Controls.Clear();
            this.groupControlClientArea.Controls.Add(uctQuanLyNguyenLieu);
            this.currentTabName = config.TAB_NGUYEN_LIEU;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DisableButton();
        }


    }
}
