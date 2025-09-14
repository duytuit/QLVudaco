using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_vudaco.Forms
{
    public partial class frmFileGia_Qly : DevExpress.XtraEditors.XtraForm
    {
        public frmFileGia_Qly()
        {
            InitializeComponent();
        }
        public frmFileGia_Qly(int IDLoHang)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
        }
        public frmFileGia_Qly(int IDLoHang, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _sua = sua;
        }
        public frmFileGia_Qly(int IDLoHang,string SoFile, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _sua = sua;
            _SoFile = SoFile;
        }
        public frmFileGia_Qly(int IDLoHang, string SoFile,int _IDGia, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _sua = sua;
            _SoFile = SoFile;
            IDGia = _IDGia;
        }
        public frmFileGia_Qly(int IDLoHang, string SoFile, int _IDGia,int _IDCP, int sua)
        {
            InitializeComponent();
            _IDLoHang = IDLoHang;
            _sua = sua;
            _SoFile = SoFile;
            IDGia = _IDGia;
            idcp = _IDCP;
        }
        int _IDLoHang = 0, _sua = 0;
        int IDGia = 0, idcp = 0;
        string _SoFile = "";
        ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

        DataTable dtFull = new DataTable("table");
        private void frmBangKeChiPhi_Load(object sender, EventArgs e)
        {
            dtpNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboNCC.Properties.DataSource= client.ds_NCC();
            repositoryItemNhaCC.DataSource = client.ds_NCC();
            DataTable dt = client.DsThongTinFile_Full_TheoIDLoHang(_IDLoHang);
            if(dt.Rows.Count>0)
            {
                DataRow row = dt.Rows[0];
                lblKh.Text = row["TenKhachHang"].ToString();
                lblSoFile.Text= row["SoFile"].ToString();
                lblSoToKhai.Text = row["SoToKhai"].ToString();
                lblSoBill.Text = row["SoBill"].ToString();
                lblSoLuong.Text = row["SoLuong"].ToString();
                lblSoCont.Text = row["SoCont"].ToString();
                lblTenSales.Text = row["TenSales"].ToString();
                lblTenGiaoNhan.Text = row["TenGiaoNhan"].ToString();
                lblLoaiHang.Text = row["LoaiHang"].ToString();
                lblTinhChat.Text = row["TinhChat"].ToString();
                lblSoLuongtoKhai.Text = row["SoLuongToKhai"].ToString();
                lblLoaiToKhai.Text = row["LoaiToKhai"].ToString();
                lblNghiepVu.Text= row["NghiepVu"].ToString();
                lblPhatSinh.Text = row["PhatSinh"].ToString();
                lblDuyetUng.Text=(row["DuyetUng"].ToString()=="")?"0":double.Parse( row["DuyetUng"].ToString()).ToString("#,##");
                //chi tiet
                //IDGia = int.Parse("0"+ row["IDGia"].ToString());
                //DataTable dtCT= client.DsChiPhiHQ_TheoLoHang(_IDLoHang);
                DataTable dtCT = client.DsChiPhiHQ_TheoSoFile2(lblSoFile.Text, _IDLoHang,idcp);
                gridControl1.DataSource = dtCT;
                dtCT.Columns.Add("MaNhaCungCap");
                dtFull = dtCT;

            }    
            if(_sua==1)
            {
               var t2= client.FileGia_TheoIDGia(IDGia);
                foreach (var item in t2)
                {
                    dtpNgay.Text = item.ThoiGianLap.Value.ToString("dd/MM/yyyy");
                }
                var t= client.BangFileGiaDaTao_ChiTiet(IDGia);
                DataTable dt1 = new DataTable("table");
                dt1.Columns.Add("TenDichVu");
                dt1.Columns.Add("GiaMua", typeof(float));
                dt1.Columns.Add("GiaBan", typeof(float));
                dt1.Columns.Add("GhiChu");
                dt1.Columns.Add("MaNhaCungCap");
                foreach (var item in t)
                {
                    DataRow row = dt1.NewRow();
                    row["TenDichVu"] = item.TenDichVu;
                    row["GiaMua"] = item.GiaMua;
                    row["GiaBan"] = item.GiaBan;
                    row["MaNhaCungCap"] = item.MaNhaCungCap;
                    row["GhiChu"] = item.GhiChu;
                    dt1.Rows.Add(row);
                }
                dtFull = dt1;
                gridControl1.DataSource = dtFull;
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }    
            else
            {
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            LoadLoiNhuan();
        }
        private void LoadLoiNhuan()
        {
            double tongMua = 0, tongBan = 0;
            for (int i = 0; i < dtFull.Rows.Count; i++)
            {   
                tongMua += double.Parse(dtFull.Rows[i]["GiaMua"].ToString().Trim());
                tongBan += double.Parse(dtFull.Rows[i]["GiaBan"].ToString().Trim());
            }
            lblTongMua.Text = (tongMua == 0) ? "0" : tongMua.ToString("#,##");
            lblTongBan.Text = (tongBan == 0) ? "0" : tongBan.ToString("#,##");
            double loiNhuan = tongBan - tongMua;
            lblLoiNhuan.Text =(loiNhuan==0)?"0": loiNhuan.ToString("#,##");
        }

        private void btnXoaHQ_Click(object sender, EventArgs e)
        {
            string _nd = gridView1.GetFocusedRowCellValue("TenDichVu").ToString().Trim().ToLower();
            if (_nd != "phí chi hộ" || _nd == "phí đăng ký kiểm tra chất lượng" || _nd == "chi phí hải quan")
            {
                gridView1.DeleteRow(dong_HQ);
                gridView1.RefreshData();
                // dong_HQ = -1;
                LoadLoiNhuan();
            }
            else
                MessageBox.Show("Không được xoá phí chi hộ!");
        }
        int dong_HQ = -1, dong_ChiHo = 0;

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            try
            {
                gridControl1.DataSource = dtFull;
                dong_HQ = gridView1.FocusedRowHandle;
                _giaMua = double.Parse(gridView1.GetFocusedRowCellValue("GiaMua").ToString().Trim());
            }
            catch (Exception)
            {
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl1.DataSource = dtFull;
                dong_HQ = gridView1.FocusedRowHandle;
            }
            catch (Exception)
            {
            }
        }

        private void gridView2_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            //try
            //{
            //    gridControl1.DataSource = dtFull;
            //}
            //catch (Exception)
            //{
            //}
        }

        //private void gridView2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
                
        //            gridControl1.DataSource = dtFull;
               
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            bool kt = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if(!gridView1.IsNewItemRow(i))
                {
                    if (gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim()=="")
                    {
                        kt = true;
                        break;
                    }
                    if (gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim() == "Vui lòng nhập tuyến vận chuyển")
                    {
                        kt = true;
                        break;
                    }

                }
            }
            if (kt)
                MessageBox.Show("Chưa nhập nhật ký hàng ngày!");
            else
            {
                ServiceReference1.FileGia p1 = new ServiceReference1.FileGia();
                p1.IDLoHang = _IDLoHang;
              var tCheck=  client.BangKe_TheoIDLoHang(_IDLoHang);
                if (tCheck.Count() == 0)
                    MessageBox.Show("Chưa tạo bảng kê chi phí cho lô hàng này. Vui lòng tạo trước rồi quay trở lại!");
                else
                {
                    p1.SoFile = lblSoFile.Text;
                    string[] arr1 = dtpNgay.Text.Split('/');
                    DateTime Ngay1 = new DateTime(int.Parse(arr1[2]), int.Parse(arr1[1]), int.Parse(arr1[0]));
                    p1.ThoiGianLap = Ngay1;
                    p1.NguoiLap = frmMain._TK;
                    p1.MaDieuXe = "";
                    p1.Duyet = false;
                    client.LuuFileGia(p1);
                    //
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!gridView1.IsNewItemRow(i))
                        {
                            ServiceReference1.FileGiaChiTiet p2 = new ServiceReference1.FileGiaChiTiet();
                            p2.IDCP = idcp;
                            p2.TenDichVu = gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim();
                            if (gridView1.GetRowCellDisplayText(i, "GiaMua").Trim() == "")
                                p2.GiaMua = 0;
                            else
                                p2.GiaMua = double.Parse(gridView1.GetRowCellDisplayText(i, "GiaMua").Trim());

                            if (gridView1.GetRowCellDisplayText(i, "GiaBan").Trim() == "")
                                p2.GiaBan = 0;
                            else
                                p2.GiaBan = double.Parse(gridView1.GetRowCellDisplayText(i, "GiaBan").Trim());
                            p2.GhiChu = gridView1.GetRowCellDisplayText(i, "GhiChu").Trim();
                            p2.MaNhaCungCap = (gridView1.GetRowCellValue(i, "MaNhaCungCap") != null) ? gridView1.GetRowCellValue(i, "MaNhaCungCap").ToString().Trim() : "";
                            if (p2.TenDichVu != "")
                                client.LuuFileGiaChiTiet(p2);
                        }
                    }
                    MessageBox.Show("Thao tác thành công!");
                    this.Close();
                }
            }
        }
        double _giaMua = 0;
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            //try
            //{
               
            //    if (e.Column.FieldName == "GiaMua" && e.RowHandle > 2)
            //    {
            //        gridView1.SetFocusedRowCellValue("GiaMua", _giaMua);
            //        gridView1.RefreshData();
            //        dtFull = (DataTable)gridControl1.DataSource;
                   LoadLoiNhuan();
            //    }
               
            //}
            //catch (Exception)
            //{

            //}
           
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
           // LoadLoiNhuan();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtTenDichVu.Text != "")
            {
                DataRow row = dtFull.NewRow();
                row["MaNhaCungCap"] = (cboNCC.EditValue!=null)? cboNCC.EditValue.ToString():"";
                row["TenDichVu"] = txtTenDichVu.Text.Trim();
                row["GiaMua"] = (txtGiaMua.Text == "") ? 0 : double.Parse(txtGiaMua.Text);
                row["GiaBan"] = (txtGiaBan.Text == "") ? 0 : double.Parse(txtGiaBan.Text);
                row["GhiChu"] = txtGhiChu.Text;
                dtFull.Rows.Add(row);
                gridControl1.DataSource = dtFull;
                LoadLoiNhuan();
            }
            else
                MessageBox.Show("Vui lòng nhập tên dịch vụ!");
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index = e.RowHandle;
            string nd = gridView1.GetRowCellDisplayText(index, "TenDichVu").Trim().ToLower();
            if (nd != "phí chi hộ")
            {
                if (e.Column.FieldName == "GiaMua" && e.RowHandle <= 2)
                {
                    //if(_sua!=1)
                    gridControl1.DataSource = dtFull;

                    gridView1.RefreshRow(e.RowHandle);
                }
            }
            else
                gridView1.RefreshRow(e.RowHandle);
        }

        private void txtTenDichVu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            client.XoaFileGiaChiTiet_TheoIDGia(IDGia);
            bool kt = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!gridView1.IsNewItemRow(i))
                {
                    if (gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim() == "")
                    {
                        kt = true;
                        break;
                    }
                    if (gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim() == "Vui lòng nhập tuyến vận chuyển")
                    {
                        kt = true;
                        break;
                    }

                }
            }
            if (kt)
                MessageBox.Show("Chưa nhập nhật ký hàng ngày!");
            else
            {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!gridView1.IsNewItemRow(i))
                        {
                            ServiceReference1.FileGiaChiTiet p2 = new ServiceReference1.FileGiaChiTiet();
                           p2.IDGia = IDGia;
                            p2.IDCP = idcp;
                            p2.TenDichVu = gridView1.GetRowCellDisplayText(i, "TenDichVu").Trim();
                            if (gridView1.GetRowCellDisplayText(i, "GiaMua").Trim() == "")
                                p2.GiaMua = 0;
                            else
                                p2.GiaMua = double.Parse(gridView1.GetRowCellDisplayText(i, "GiaMua").Trim());

                            if (gridView1.GetRowCellDisplayText(i, "GiaBan").Trim() == "")
                                p2.GiaBan = 0;
                            else
                                p2.GiaBan = double.Parse(gridView1.GetRowCellDisplayText(i, "GiaBan").Trim());
                            p2.GhiChu = gridView1.GetRowCellDisplayText(i, "GhiChu").Trim();
                            p2.MaNhaCungCap = (gridView1.GetRowCellValue(i, "MaNhaCungCap") != null) ? gridView1.GetRowCellValue(i, "MaNhaCungCap").ToString().Trim() : "";
                            if (p2.TenDichVu != "")
                                client.LuuFileGiaChiTiet1(p2);
                        }
                    }
                client.BangFileGia_Duyet(IDGia, frmMain._TK, DateTime.Now, txtLyDo.Text);
                MessageBox.Show("Thao tác thành công!");
                this.Close();

            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool check = client.FileGia_KiemTraFileDebit(IDGia);
            if (check)
                MessageBox.Show("File giá này có dữ liệu liên quan File Debit, vui lòng xóa ở File Debit trước để tiếp tục!");
            else
            {
                client.XoaFileGia_TheoIDGia(IDGia);
                btnLuu_Click_1(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá không (Y/N)","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                //FileGia_KiemTraFileDebit
                bool check = client.FileGia_KiemTraFileDebit(IDGia);
                if (check)
                    MessageBox.Show("File giá này có dữ liệu liên quan File Debit, vui lòng xóa ở File Debit trước để tiếp tục!");
                else
                {
                    client.BangFileGia_Duyet_Xoa(IDGia);
                    frmBangKeChiPhi_Load(sender, e);
                }
            }    
        }

    }
}