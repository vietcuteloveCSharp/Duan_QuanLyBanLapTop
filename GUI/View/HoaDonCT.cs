using BUS.Service;
using BUS.Service2;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.View
{
    public partial class HoaDonCT : Form
    {
        TaikhoanSevrvice TKservoce = new TaikhoanSevrvice();
        KhachHangServices KHService = new KhachHangServices();
        HoaDonService service = new HoaDonService();
        HoaDonCTService serviceCT = new HoaDonCTService();
        LapTopCTService LapTopCTService = new LapTopCTService();
        LaptopServices _service = new LaptopServices();
        ChipServices _services = new ChipServices();
        RamServices _servicesRam = new RamServices();
        OcungServices _servicesSSD = new OcungServices();
        CardServices _cardServices = new CardServices();
        PinServices _pinServices = new PinServices();
        HangSevices _hangservice = new HangSevices();
        int IdHDCT;
        int idhd;
        public HoaDonCT(bool b, int id)
        {
            idhd = id;
            InitializeComponent();
            if (b == true)
            {
                loadGridViewHoaDonCT();
                LoadInforHoaDon();
                LoadAllCmb();
                btnNhapKho.Visible = false;
            }
            else
            {
                LoadAllCmb();
                loadNull();
                btnNhapKho.Visible = true;
            }
        }


        public void loadGridViewHoaDonCT()
        {
            int stt = 1;
            txtTongTien.Text = MoneySum(idhd).ToString();
            dtgHoaDonCT.Rows.Clear();
            foreach (var item in serviceCT.GetByInt(idhd, "FK"))
            {
                dtgHoaDonCT.Rows.Add(stt++, item.IdHdct, item.Imel, item.Gia, serviceCT.GetLapTopName(item.Imel));
            }
        }
        //txtKhachHang
        public void LoadInforHoaDon()
        {
            var ONE = service.GetOne(idhd);
            cmbKhachHang.SelectedValue = ONE.IdKhachhang;
            cmbTaiKhoan.SelectedValue = ONE.IdTaikhoan;
            TimPicPhieuNhap.Value = ONE.Ngaymua;
            txtTongTien.Text = ONE.Tongtien.ToString();
            txtGhiChu.Text = ONE.Chuthich;
        }
        public void loadLapTopCT(string Imel)
        {
            var LTCT = LapTopCTService.Getone(Imel);
            txtImel.Text = Imel;
            txtGiaNhap.Text = LTCT.Gianhap.ToString();

            cmbCard.SelectedValue = LTCT.IdCarddohoa;

            cmbChip.SelectedValue = LTCT.IdChip;


            cmbHang.SelectedValue = LTCT.IdHang;


            cmbPin.SelectedValue = LTCT.IdPin;

            cmbRam.SelectedValue = LTCT.IdRam;


            cmbOCung.SelectedValue = LTCT.IdOcung;


            cmbLoaiMay.SelectedValue = LTCT.IdLaptop;
        }
        public void loadNull()
        {
            txtImel.Text = null;
            txtGiaNhap.Text = null;
            cmbChip.SelectedValue = 0;
            cmbCard.SelectedValue = 0;
            cmbHang.SelectedValue = 0;
            cmbLoaiMay.SelectedValue = 0;
            cmbOCung.SelectedValue = 0;
            cmbPin.SelectedValue = 0;
            cmbRam.SelectedValue = 0;

        }
        public void LoadAllCmb()
        {
            List<Taikhoan> TK = TKservoce.Gettaikhoan();

            cmbTaiKhoan.DataSource = TK;
            cmbTaiKhoan.ValueMember = "IdTaikhoan";
            cmbTaiKhoan.DisplayMember = "Hoten";

            List<Khachhang> KH = KHService.GetAllKH();
            cmbKhachHang.DataSource = KH;
            cmbKhachHang.ValueMember = "IdKhachhang";
            cmbKhachHang.DisplayMember = "Tenkh";

            List<Carddohoa> card = _cardServices.GetAllCard();

            cmbCard.DataSource = card;
            cmbCard.ValueMember = "IdCarddohoa";
            cmbCard.DisplayMember = "Tencard";

            List<Chip> chip = _services.GetAllChip();

            cmbChip.DataSource = chip;
            cmbChip.ValueMember = "IdChip";
            cmbChip.DisplayMember = "Tenchip";

            List<Hang> hang = _hangservice.GetAllHang();
            cmbHang.DataSource = hang;
            cmbHang.ValueMember = "IdHang";
            cmbHang.DisplayMember = "Tenhang";

            List<Pin> pin = _pinServices.GetAllPin();
            cmbPin.DataSource = pin;
            cmbPin.ValueMember = "IdPin";
            cmbPin.DisplayMember = "Tenpin";

            List<Ram> ram = _servicesRam.GetAllRam();
            cmbRam.DataSource = ram;
            cmbRam.ValueMember = "IdRam";
            cmbRam.DisplayMember = "Tenram";

            List<Ocung> ocung = _servicesSSD.GetAllOcung();
            cmbOCung.DataSource = ocung;
            cmbOCung.ValueMember = "IdOcung";
            cmbOCung.DisplayMember = "Tenocung";

            List<Laptop> laptop = _service.GetAllLaptop();
            cmbLoaiMay.DataSource = laptop;
            cmbLoaiMay.ValueMember = "IdLt";
            cmbLoaiMay.DisplayMember = "Tenlaptop";

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void dtgHoaDonCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadNull();
            string Imel;
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                IdHDCT = Convert.ToInt32(dtgHoaDonCT.Rows[rowIndex].Cells[1].Value.ToString());
                Imel = dtgHoaDonCT.Rows[rowIndex].Cells[2].Value.ToString();
            }

            loadLapTopCT(Imel);
        }

        private void dtgHoaDonCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadNull();
            string Imel;
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }
            else
            {
                IdHDCT = Convert.ToInt32(dtgHoaDonCT.Rows[rowIndex].Cells[1].Value.ToString());
                Imel = dtgHoaDonCT.Rows[rowIndex].Cells[2].Value.ToString();
            }

            loadLapTopCT(Imel);
        }
        public decimal MoneySum(int id_kho)
        {
            decimal TT = 0;
            foreach (Hoadonct item in serviceCT.GetByInt(id_kho, "FK"))
            {
                TT += item.Gia;
            }
            return TT;
        }
        private void btnNhapKho_Click(object sender, EventArgs e)
        {


            var HD = service.GetOne(idhd);
            HD.Ngaymua = TimPicPhieuNhap.Value;
            HD.Chuthich = txtGhiChu.Text;
            HD.Tongtien = MoneySum(idhd);
            HD.Trangthai = false;
            HD.IdTaikhoan = (int)cmbTaiKhoan.SelectedValue;
            HD.IdKhachhang = (int)cmbKhachHang.SelectedValue;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = service.Update(HD);//yêu cầu sửa id ng nhập từ 0 => ?

                if (add)
                {
                    MessageBox.Show("Thêm mới thành công!");
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

        private void guna2Button4_Click(object sender, EventArgs e)//btnSuaPhieu
        {
            loadGridViewHoaDonCT();
            var HD = service.GetOne(idhd);
            HD.Ngaymua = TimPicPhieuNhap.Value;
            HD.Chuthich = txtGhiChu.Text;
            HD.Tongtien = MoneySum(idhd);
            HD.Trangthai = false;
            HD.IdTaikhoan = (int)cmbTaiKhoan.SelectedValue;
            HD.IdKhachhang = (int)cmbKhachHang.SelectedValue;

            DialogResult result = MessageBox.Show("Bạn có muốn Sửa không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = service.Update(HD);//yêu cầu sửa id ng nhập từ 0 => ?

                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
        }





        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)//btnThanhToan
        {
            loadGridViewHoaDonCT();
            var HD = service.GetOne(idhd);
            HD.Ngaymua = TimPicPhieuNhap.Value;
            HD.Chuthich = txtGhiChu.Text;
            HD.Tongtien = MoneySum(idhd);
            HD.Trangthai = true;
            HD.IdTaikhoan = (int)cmbTaiKhoan.SelectedValue;
            HD.IdKhachhang = (int)cmbKhachHang.SelectedValue;

            DialogResult result = MessageBox.Show("Bạn có muốn thanh toán không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = service.Update(HD);//yêu cầu sửa id ng nhập từ 0 => ?

                if (add)
                {
                    MessageBox.Show(" thanh toán thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi  thanh toán.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối  thanh toán.");
            }
        }

        private void btnThemSP_Phieu_Click(object sender, EventArgs e)
        {
            if (txtImel.Text == null)
            {
                MessageBox.Show("Tìm ra sp trước đi");
                return;
            }
            Hoadonct hdct = new Hoadonct();
            hdct.Imel = txtImel.Text;
            hdct.IdHoadon = idhd;
            //if (!Regex.IsMatch(txtGiaNhap.Text, @"^[0-9]+$"))
            //{
            //    MessageBox.Show("mời nhập đúng giá nhập");
            //    return;
            //}
            hdct.Gia = Convert.ToDecimal(txtGiaNhap.Text);


            //txtImel.Text = ltct.Imel;
            //Hoadonct hdct = new Hoadonct();
            //hdct.Imel = ltct.Imel;
            //hdct.IdHoadon = idhd;
            //hdct.Gia = (decimal)ltct.Gianhap;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = serviceCT.AddNew(hdct);
                if (add)
                {
                    MessageBox.Show("Thêm mới thành công!");
                    Laptopchitiet ltct = LapTopCTService.Getone(hdct.Imel);
                    ltct.TrangThai = false;
                    LapTopCTService.Update(ltct);
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
            loadGridViewHoaDonCT();
        }

        private void btnSuaSP_Phieu_Click(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(txtGiaNhap.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("mời nhập đúng giá nhập");
                return;
            }
            Hoadonct hdct = serviceCT.GetAll().FirstOrDefault(x => x.IdHdct == IdHDCT);
            String Imel1 = hdct.Imel;
            hdct.Imel = txtImel.Text;
            hdct.IdHoadon = idhd;
            hdct.Gia = Convert.ToDecimal(txtGiaNhap.Text);
            if (txtImel.Text == hdct.Imel)
            {
                MessageBox.Show("Mời tìm máy mới rồi hẵng thêm!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn Sửa không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            //DialogResult result = MessageBox.Show("Bạn có muốn Xóa không?", "Thông báo",
            //   MessageBoxButtons.YesNo,
            //   MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = serviceCT.Update(hdct);//yêu cầu sửa id ng nhập từ 0 => ?

                if (add)
                {

                    Laptopchitiet ltct = LapTopCTService.Getone(Imel1);
                    ltct.TrangThai = true;
                    LapTopCTService.Update(ltct);

                    MessageBox.Show("Xóa thành công!");

                    Laptopchitiet ltct1 = LapTopCTService.Getone(hdct.Imel);
                    ltct1.TrangThai = false;
                    LapTopCTService.Update(ltct1);
                }
                else
                {
                    MessageBox.Show("Lỗi khi Xóa.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Xóa.");
            }
            loadGridViewHoaDonCT();
        }

        private void btnXoaSp_Phieu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn Xóa không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (IdHDCT == null)
                {
                    MessageBox.Show("Không xoá được gì đâu,chọn được rồi hãy xoá!");
                    return;
                }
                Hoadonct hdct = serviceCT.GetAll().FirstOrDefault(x => x.IdHdct == IdHDCT);
                txtImel.Text = hdct.Imel;
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = serviceCT.Delete(IdHDCT);//yêu cầu sửa id ng nhập từ 0 => ?

                if (add)
                {
                    MessageBox.Show("Xóa thành công!");

                    Laptopchitiet ltct1 = LapTopCTService.Getone(hdct.Imel);
                    ltct1.TrangThai = true;
                    LapTopCTService.Update(ltct1);
                }
                else
                {
                    MessageBox.Show("Lỗi khi Xóa.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Xóa.");
            }
            loadGridViewHoaDonCT();
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if (cmbCard.SelectedValue == null || cmbChip.SelectedValue == null || cmbHang.SelectedValue == null || cmbLoaiMay.SelectedValue == null || cmbOCung.SelectedValue == null || cmbPin.SelectedValue == null || cmbRam.SelectedValue == null)
            {
                MessageBox.Show("Mời chọn đủ cấu hình máy");
                return;
            }
            Laptopchitiet ltct = LapTopCTService.GetAll().FirstOrDefault(x => x.IdChip == Convert.ToInt32(cmbChip.SelectedValue.ToString()) &&
            x.IdLaptop == Convert.ToInt32(cmbLoaiMay.SelectedValue.ToString()) &&
             x.IdCarddohoa == Convert.ToInt32(cmbCard.SelectedValue.ToString()) &&
            x.IdHang == Convert.ToInt32(cmbHang.SelectedValue.ToString()) &&
            x.IdOcung == Convert.ToInt32(cmbOCung.SelectedValue.ToString()) &&
            x.IdPin == Convert.ToInt32(cmbPin.SelectedValue.ToString()) &&
            x.IdRam == Convert.ToInt32(cmbRam.SelectedValue.ToString()) && x.TrangThai == true
);
            if (ltct == null)
            {
                MessageBox.Show("Sản phẩm có cấu hình này chưa có trong kho");
                return;
            }

            txtGiaNhap.Text = null;
            if (ltct.Gianhap != null)
            {

                txtGiaNhap.Text = ltct.Gianhap.ToString();
            }
            txtImel.Text = ltct.Imel;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
