﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Title.Config;
using Title.BUS;
using DevExpress.XtraGrid.Views.Grid;
using Title.VO;

namespace Title.GUI
{
    public partial class UctQuanLyNguyenLieu : UserControl
    {
        public UctQuanLyNguyenLieu()
        {
            InitializeComponent();
        }

        Configuration config = new Configuration();

        public string currentAction;

        public void LoadData()
        {
            DataTable dataTable = new DataTable();
            dataTable = Bus.GetListNguyenLieu();
            this.gridControlNguyenLieu.DataSource = dataTable;
        }
        private void gridControlNguyenLieu_Load(object sender, EventArgs e)
        {
            
            LoadData();
        }

        public void ClearText()
        {
            this.textEditMaNL.Text = "";
            this.textEditTenNL.Text = "";
            this.textEditDonVi.Text = "";
            this.textEditDonGia.Text = "";
        }

        public void Add()
        {
            ClearText();
            this.panelNguyenLieu.Enabled = true;
            this.currentAction = "Add";
        }

        public void Edit()
        {
            this.panelNguyenLieu.Enabled = true;
            this.currentAction = "Edit";
        }

        public void Delete()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete it?", "Delete Value", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string maNL = this.textEditMaNL.Text;
                NguyenLieu nl = new NguyenLieu();
                nl.MaNguyenLieu = maNL;
                int res = Bus.DeleteNguyenLieu(nl);
                if (res == 1)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
            }
            this.panelNguyenLieu.Enabled = false;
        }

        public void Save()
        {
            try
            {
                string maNL, donVi, tenNL;
                int donGia;
                maNL = this.textEditMaNL.Text;
                tenNL = this.textEditTenNL.Text;
                donVi = this.textEditDonVi.Text;
                donGia = int.Parse(this.textEditDonGia.Text);
                NguyenLieu nl = new NguyenLieu(maNL, tenNL, donVi, donGia);
                if (this.currentAction == "Add")
                {
                    int res = Bus.InsertNguyenLieu(nl);
                    if (res == 1)
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm mới thành công");
                   
                    }
                }
                if (this.currentAction == "Edit")
                {
                    int res = Bus.UpdateNguyenLieu(nl);
                    if (res == 1)
                    {
                        LoadData();
                        MessageBox.Show("Đã sửa thành công");
                        
                    }
                }
                this.panelNguyenLieu.Enabled = false;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Cancel()
        {
            this.panelNguyenLieu.Enabled = false;
        }

        private void gridViewNguyenLieu_RowClick(object sender, RowClickEventArgs e)
        {
            int[] selRows = ((GridView)gridControlNguyenLieu.MainView).GetSelectedRows();
            DataRowView selRow = (DataRowView)(((GridView)gridControlNguyenLieu.MainView).GetRow(selRows[0]));
            this.textEditMaNL.Text = selRow["MaNL"].ToString();
            this.textEditTenNL.Text = selRow["TenNL"].ToString();
            this.textEditDonVi.Text = selRow["DonVi"].ToString();
            this.textEditDonGia.Text = selRow["DonGia"].ToString();
        }

    }
}
