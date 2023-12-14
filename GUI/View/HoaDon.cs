using BUS.Service;
using BUS.Service2;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using exel = Microsoft.Office.Interop.Excel;

//using app = Microsoft.Office.Interop.Excel.Application;
//Microsoft.Office.Interop.Excel.Workbook workbook
//Microsoft.Office.Interop.Excel.Worksheet worksheet

///
/// using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
///
namespace GUI.View
{
    public partial class HoaDon : Form
    {
        HoaDonService service = new HoaDonService();
        HoaDonCTService serviceCT = new HoaDonCTService();
        KhachHangServices serviceKH = new KhachHangServices();
        TaikhoanSevrvice serviceTK = new TaikhoanSevrvice();
        int IdHD;
        int IDTK;
        public HoaDon(int IDTk)
        {
            IDTK = IDTk;
            InitializeComponent();

            loadCmbTimKiem();
        }
        public Khachhang GetNgMua(int id)
        {
            return serviceKH.GetOne(id);
        }
        public Taikhoan GetNgNhap(int id)
        {
            return serviceTK.Gettaikhoan().FirstOrDefault(x => x.IdTaikhoan == id);
        }
        public void loadGridViewHoaDon(List<Hoadon> nhap)
        {
            dtgHoaDonTT.Rows.Clear();
            foreach (var item in nhap)
            {
                dtgHoaDonTT.Rows.Add(item.IdHoadon, GetNgMua((int)item.IdKhachhang).Tenkh, GetNgNhap((int)item.IdTaikhoan).Hoten, item.Ngaymua, item.Tongtien, item.Chuthich, item.Trangthai ? "Còn hàng" : "Hết Hàng");
            }
        }
        public void loadGridViewHoaDonCho(List<Hoadon> nhap)
        {
            dtgHoaDonCho.Rows.Clear();
            foreach (var item in nhap)
            {
                dtgHoaDonCho.Rows.Add(item.IdHoadon, GetNgMua((int)item.IdKhachhang).Tenkh, GetNgNhap((int)item.IdTaikhoan).Hoten, item.Ngaymua, item.Tongtien, item.Chuthich, item.Trangthai ? "Còn hàng" : "Hết Hàng");
            }
        }
        public void loadCmbTimKiem()
        {
            List<string> list = new List<string>();
            list.Add("Mã Hóa Đơn");
            list.Add("Người Mua");
            list.Add("Người Nhập");
            list.Add("Tổng Tiền");
            list.Add("Chú Thích");
            cmbTimKiem.DataSource = list;
            loadGridViewHoaDon(service.GetByBool(true));
            loadGridViewHoaDonCho(service.GetByBool(false));
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int getID()
        {
            return IdHD;
        }
        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm Hóa đơn mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện thêm mới chỉ khi tất cả điều kiện đều đúng

                Hoadon nhaphang = new Hoadon()
                {
                    Ngaymua = DateTime.Now,
                    Chuthich = "",
                    Tongtien = 0,
                    Trangthai = false,
                    IdTaikhoan = serviceTK.Gettaikhoan().FirstOrDefault().IdTaikhoan,
                    IdKhachhang = serviceKH.GetAllKH().FirstOrDefault().IdKhachhang
                };

                bool add = service.AddNew(nhaphang);

                IdHD = nhaphang.IdHoadon;
                if (add)
                {
                    MessageBox.Show("Thêm mới thành công!");
                    HoaDonCT hdct = new HoaDonCT(false, IdHD);
                    hdct.Show();
                    
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm mới.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối thêm mới.");
            }
         
        }
        private void btnNhapKho_Click(object sender, EventArgs e)
        {

        }
        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            HoaDonCT HDTC = new HoaDonCT(true, IdHD);
            HDTC.Show();
            this.Hide();
        }

        private void Kho_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void txtTimkiemHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                //{
                //    list.Add("Mã Hóa Đơn");
                //    list.Add("Người Mua");
                //    list.Add("Người Nhập");
                //    list.Add("Tổng Tiền");
                //    list.Add("Chú Thích");

                if (cmbTimKiem.SelectedValue == "Mã Hóa Đơn")
                {
                    var id = Convert.ToInt32(txtTimkiemHD.Text);
                    loadGridViewHoaDon(service.GetByInt(id, "PK").Where(x => x.Trangthai == true).ToList());
                    loadGridViewHoaDonCho(service.GetByInt(id, "PK").Where(x => x.Trangthai == false).ToList());
                }
                else if (cmbTimKiem.SelectedValue == "Người Mua")
                {

                    var id = Convert.ToInt32(txtTimkiemHD.Text);
                    loadGridViewHoaDon(service.GetByInt(id, "").Where(x => x.Trangthai == true).ToList());
                    loadGridViewHoaDonCho(service.GetByInt(id, "").Where(x => x.Trangthai == false).ToList());

                }
                else if (cmbTimKiem.SelectedValue == "Người Nhập")
                {

                    var id = Convert.ToInt32(txtTimkiemHD.Text);
                    loadGridViewHoaDon(service.GetByInt(id, "FK_TK").Where(x => x.Trangthai == true).ToList());
                    loadGridViewHoaDonCho(service.GetByInt(id, "FK_TK").Where(x => x.Trangthai == false).ToList());

                }
                else if (cmbTimKiem.SelectedValue == "Tổng Tiền")
                {
                    loadGridViewHoaDon(service.GetByDecimal(Convert.ToDecimal(txtTimkiemHD.Text)).Where(x => x.Trangthai == true).ToList());
                    loadGridViewHoaDonCho(service.GetByDecimal(Convert.ToDecimal(txtTimkiemHD.Text)).Where(x => x.Trangthai == false).ToList());

                }
                else if (cmbTimKiem.SelectedValue == "Chú Thích")
                {
                    var id = txtTimkiemHD.Text;
                    loadGridViewHoaDon(service.GetByString(id).Where(x => x.Trangthai == true).ToList());
                    loadGridViewHoaDonCho(service.GetByString(id).Where(x => x.Trangthai == false).ToList());

                }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            loadGridViewHoaDon(service.GetByBool(true));
            loadGridViewHoaDonCho(service.GetByBool(false));
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            loadGridViewHoaDon(service.GetByDateTime(TmPicTu.Value, TimPicDen.Value).Where(x => x.Trangthai == true).ToList());
            loadGridViewHoaDonCho(service.GetByDateTime(TmPicTu.Value, TimPicDen.Value).Where(x => x.Trangthai == false).ToList());

        }

        //private void dtgHoaDonTT_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int rowIndex = e.RowIndex;
        //    if (rowIndex < 0)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        IdHD = Convert.ToInt32(dtgHoaDonTT.Rows[rowIndex].Cells[0].Value.ToString());

        //    }
        //    HoaDonCT HDTC = new HoaDonCT(true,IdHD);
        //    HDTC.Show();
        //}

        private void dtgHoaDonTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                IdHD = Convert.ToInt32(dtgHoaDonTT.Rows[rowIndex].Cells[0].Value.ToString());

            }
            HoaDonCT HDTC = new HoaDonCT(true, IdHD);
            HDTC.Show();
        }

        //private void dtgHoaDonCho_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int rowIndex = e.RowIndex;
        //    if (rowIndex < 0)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        IdHD = Convert.ToInt32(dtgHoaDonCho.Rows[rowIndex].Cells[0].Value.ToString());
        //    }
        //    HoaDonCT HDTC = new HoaDonCT(true, IdHD);
        //    HDTC.Show();
        //}

        private void dtgHoaDonCho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                IdHD = Convert.ToInt32(dtgHoaDonCho.Rows[rowIndex].Cells[0].Value.ToString());
            }
            HoaDonCT HDTC = new HoaDonCT(true, IdHD);
            HDTC.Show();

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Hoadon hd = service.GetByInt(IdHD, "PK").FirstOrDefault();
            if (hd.Trangthai == true)
            {
                MessageBox.Show("Hoá đơn đã thanh toán");
            }
            DialogResult = MessageBox.Show("Bạn có muốn xóa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {

                bool delete = service.delete(IdHD);
                if (delete)
                {
                    MessageBox.Show("xóa thành công");

                }
                else
                {

                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
            {
                MessageBox.Show("Từ chối xóa");
            }
            loadGridViewHoaDon(service.GetByBool(true));
            loadGridViewHoaDonCho(service.GetByBool(false));

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            Hoadon hd = service.GetOne(IdHD);hd.Trangthai = true;

            DialogResult result = MessageBox.Show("Bạn có muốn Thanh Toán không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = service.Update(hd);//yêu cầu sửa id ng nhập từ 0 => ?

                if (add)
                {
                    MessageBox.Show("Thanh Toán thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Thanh Toán.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Thanh Toán.");
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
        }
        //private void ToExcel(DataGridView dtg, string fileName)
        //{
        //    //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
        //    app excel = new app();

        //    try
        //    {
        //        //Tạo đối tượng COM.
        //        excel = new Microsoft.Office.Interop.Excel.Application();
        //        excel.Visible = false;
        //        excel.DisplayAlerts = false;
        //        //tạo mới một Workbooks bằng phương thức add()
        //        workbook = excel.Workbooks.Add(Type.Missing);
        //        worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
        //        //đặt tên cho sheet
        //        worksheet.Name = "Quản Lý Nhập Kho";
        //        // export header trong DataGridView
        //        for (int i = 0; i < dtg.ColumnCount; i++)
        //        {
        //            worksheet.Cells[1, i + 1] = dtg.Columns[i].HeaderText;
        //        }
        //        // export nội dung trong DataGridView
        //        for (int i = 0; i < dtg.RowCount; i++)
        //        {
        //            for (int j = 0; j < dtg.ColumnCount; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = dtg.Rows[i].Cells[j].Value.ToString();
        //            }
        //        }
        //        // sử dụng phương thức SaveAs() để lưu workbook với filename
        //        workbook.SaveAs(fileName);
        //        //đóng workbook
        //        workbook.Close();
        //        excel.Quit();
        //        MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        workbook = null;
        //        worksheet = null;
        //    }
        //}
        //public void DisplayInExcel(IEnumerable<Hoadon> accounts)
        //{
        //    var excelApp = new exel.Application();
        //    // Make the object visible.
        //    excelApp.Visible = true;

        //    // Create a new, empty workbook and add it to the collection returned
        //    // by property Workbooks. The new workbook becomes the active workbook.
        //    // Add has an optional parameter for specifying a particular template.
        //    // Because no argument is sent in this example, Add creates a new workbook.
        //    excelApp.Workbooks.Add();

        //    // This example uses a single workSheet. The explicit type casting is
        //    // removed in a later procedure.
        //    exel._Worksheet workSheet = (exel.Worksheet)excelApp.ActiveSheet;
        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "A"] = "Mã hóa đơn";
        //    workSheet.Cells[1, "B"] = "Người mua";
        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "C"] = "nhân viên bán";
        //    workSheet.Cells[1, "D"] = "ngày mua";
        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "E"] = "tông tiền";
        //    workSheet.Cells[1, "F"] = "chi tiết";
        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "G"] = "trạng thái";
        //    var row = 1;
        //    foreach (var acct in accounts)
        //    {
        //        row++;
        //        workSheet.Cells[row, "A"] = acct.IdHoadon;
        //        workSheet.Cells[row, "B"] = GetNgMua((int)acct.IdKhachhang).Tenkh.ToString();
        //        workSheet.Cells[row, "C"] = GetNgNhap((int)acct.IdTaikhoan).Hoten;
        //        workSheet.Cells[row, "D"] = acct.Ngaymua;
        //        workSheet.Cells[row, "E"] = acct.Tongtien;
        //        workSheet.Cells[row, "F"] = acct.Chuthich;
        //        workSheet.Cells[row, "G"] = acct.Trangthai;
        //    }
        //    for (int i = 0; i < accounts.Count(); i++)
        //    {

        //        workSheet.Columns[i + 1].AutoFit();
        //    }

        //}
        private void copyAlltoClipboard()
        {
            dtgHoaDonTT.SelectAll();
            DataObject dataObj = dtgHoaDonTT.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dtgHoaDonTT.Rows.Count > 0)
            {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new exel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (exel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                exel.Range CR = (exel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
        }
    }
}


