using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Respository2;
using BUS.Service2;
using DAL.DomainClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using BUS.Service;
using exel = Microsoft.Office.Interop.Excel;


namespace GUI.View
{
    public partial class Kho : Form
    {
        NhapKhoService service = new NhapKhoService();
        NhapKhoCTService serviceCT = new NhapKhoCTService();
        TaikhoanSevrvice serviceTK = new TaikhoanSevrvice();
        int IdHD1;
        int IdHD;
        int IDTK;
        public Kho(int tDTK)
        {
            InitializeComponent();

            loadCmbTimKiem();
            btnXoaHDCT.Visible = false;
            IDTK = tDTK;
        }
        public void XoaHD()
        {

            loadCmbTimKiem();
        }
        public Taikhoan GetNgNhap(int id)
        {
            return serviceTK.Gettaikhoan().FirstOrDefault(x => x.IdTaikhoan == id);
        }
        public void loadGridViewKho(List<Nhaphang> nhap)
        {
            dtgNhapKho.Rows.Clear();
            foreach (var item in nhap)
            {
                dtgNhapKho.Rows.Add(item.IdNhaphang, GetNgNhap((int)item.IdTaikhoan).Hoten, item.Nhacungcap, item.Ngaynhap, item.Soluongnhhap, service.MoneySum(item.IdNhaphang), item.Ghichu);
            }
        }
        public void loadCmbTimKiem()
        {
            List<string> list = new List<string>();
            list.Add("Mã Hóa Đơn");
            list.Add("Người Nhập");
            list.Add("Nhà cung cấp");
            list.Add("số lượng nhập");
            cmbTimKiem.DataSource = list;
            loadGridViewKho(service.GetAll());
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int getID()
        {
            return IdHD;
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Nhaphang nhaphang = new Nhaphang()
                {
                    Ngaynhap = DateTime.Now,
                    Nhacungcap = "",
                    Ghichu = "",
                    Soluongnhhap = 0,
                    IdTaikhoan = serviceTK.Gettaikhoan().FirstOrDefault().IdTaikhoan,
                };

                // Thực hiện thêm mới chỉ khi tất cả điều kiện đều đúng
                bool add = service.AddNew(nhaphang);
                IdHD = nhaphang.IdNhaphang;
                if (add)
                {
                    MessageBox.Show("Thêm mới thành công!");

                    NhapKho nhapKho = new NhapKho(false, IdHD);
                    nhapKho.Show();
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

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            NhapKho nhapKho = new NhapKho(true, IdHD);
            nhapKho.Show();
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
            {

                if (cmbTimKiem.SelectedValue == "Mã Hóa Đơn")
                {
                    var id = Convert.ToInt32(txtTimkiemHD.Text);
                    loadGridViewKho(service.GetByInt(id, "PK"));
                }
                else if (cmbTimKiem.SelectedValue == "Người Nhập")
                {

                }
                else if (cmbTimKiem.SelectedValue == "Nhà cung cấp")
                {
                    loadGridViewKho(service.GetByString(txtTimkiemHD.Text));
                }
                else if (cmbTimKiem.SelectedValue == "số lượng nhập")
                {
                    var id = Convert.ToInt32(txtTimkiemHD.Text);
                    loadGridViewKho(service.GetByInt(id, ""));
                }
            }
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            loadGridViewKho(service.GetByDateTime(TmPicTu.Value, TimPicDen.Value));
        }

        private void dtgNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                if (dtgNhapKho.Rows[rowIndex].Cells[0].Value != null)
                {
                    IdHD = Convert.ToInt32(dtgNhapKho.Rows[rowIndex].Cells[0].Value.ToString());
                }

            }
            loadGridViewNhapKhoCT(IdHD);
        }
        public void loadGridViewNhapKhoCT(int IdHD)
        {
            dtgNhapKhoCT.Rows.Clear();
            foreach (var item in serviceCT.GetByInt(IdHD, "FK"))
            {
                dtgNhapKhoCT.Rows.Add(item.IdNhct, item.Imel, item.Gianhap, serviceCT.GetLapTopName(item.Imel));
            }
        }

        private void btnTimKiemHD_Click_1(object sender, EventArgs e)
        {
            loadGridViewKho(service.GetByDateTime(TmPicTu.Value, TimPicDen.Value));
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }



        private void dtgNhapKhoCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                IdHD1 = Convert.ToInt32(dtgNhapKhoCT.Rows[rowIndex].Cells[0].Value.ToString());
            }

        }

        private void dtgNhapKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                IdHD = Convert.ToInt32(dtgNhapKho.Rows[rowIndex].Cells[0].Value.ToString());
            }
            loadGridViewNhapKhoCT(IdHD);
        }

        private void dtgNhapKhoCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                IdHD1 = Convert.ToInt32(dtgNhapKhoCT.Rows[rowIndex].Cells[0].Value.ToString());
            }

        }

        private void btnXoaHDCT_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool delete = serviceCT.Delete(IdHD1);
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
            loadGridViewNhapKhoCT(IdHD);
        }
        //public void DisplayInExcel(IEnumerable<Nhaphang> accounts)
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
        //    workSheet.Cells[1, "B"] = "Người Nhập";
        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "C"] = "Nhà cung cấp";
        //    workSheet.Cells[1, "D"] = "ngày nhập";
        //    // Establish column headings in cells A1 and B1.
        //    workSheet.Cells[1, "E"] = "số lượng";
        //    workSheet.Cells[1, "F"] = "Ghi chú";
        //    // Establish column headings in cells A1 and B1.
        //    var row = 1;
        //    foreach (var acct in accounts)
        //    {
        //        row++;
        //        workSheet.Cells[row, "A"] = acct.IdNhaphang;
        //        workSheet.Cells[row, "B"] = GetNgNhap((int)acct.IdTaikhoan).Hoten;
        //        workSheet.Cells[row, "C"] = acct.Nhacungcap;
        //        workSheet.Cells[row, "D"] = acct.Ngaynhap;
        //        workSheet.Cells[row, "E"] = acct.Soluongnhhap;
        //        workSheet.Cells[row, "F"] = acct.Ghichu;
        //    }
        //    for (int i = 0; i < accounts.Count(); i++)
        //    {

        //        workSheet.Columns[i + 1].AutoFit();
        //    }

        //}

        private void copyAlltoClipboard()
        {
            dtgNhapKho.SelectAll();
            DataObject dataObj = dtgNhapKho.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btnExcel_Click(object sender, EventArgs e)//btnExcel
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

        private void btnLoad_Click(object sender, EventArgs e)
        {

            loadGridViewKho(service.GetAll());
        }
    }
}
