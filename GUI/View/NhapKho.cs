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
    public partial class NhapKho : Form
    {
        HoaDonCTService hdctservice = new HoaDonCTService();
        TaikhoanSevrvice TKservoce = new TaikhoanSevrvice();
        NhapKhoService service = new NhapKhoService();
        NhapKhoCTService serviceCT = new NhapKhoCTService();
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
        public NhapKho(bool b, int id)
        {
            idhd = id;
            InitializeComponent();
            if (b)
            {
                loadGridViewNhapKhoCT();
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

            btnHuyHD.Visible = false;
        }
        public void loadGridViewNhapKhoCT()
        {
            int stt = 1;

            dtgNhapKhoCT.Rows.Clear();
            foreach (var item in serviceCT.GetByInt(idhd, "FK"))
            {
                dtgNhapKhoCT.Rows.Add(stt++, item.IdNhct, item.Imel, item.Gianhap, serviceCT.GetLapTopName(item.Imel));
            }
        }
        public void LoadInforHoaDon()
        {

            var HD = service.GetOne(idhd);
            txtNhaCC.Text = HD.Nhacungcap;
            cmbTaiKhoan.SelectedValue = HD.IdTaikhoan;//đợi tài khoản
            TimPicPhieuNhap.Value = HD.Ngaynhap;
            txtGhiChu.Text = HD.Ghichu;
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

        private void btnThemSp_HD_Click(object sender, EventArgs e)//btnThemSp_HD
        {
            if (txtImel.Text == null)
            {
                MessageBox.Show("nhập Imel Đi đã");
                return;
            }
            if (!Regex.IsMatch(txtGiaNhap.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("mời nhập đúng giá nhập");
                return;
            }
            Laptopchitiet ltct = new Laptopchitiet();
            ltct.Imel = txtImel.Text;
            ltct.Gianhap = Convert.ToDecimal(txtGiaNhap.Text);
            ltct.IdLaptop = Convert.ToInt32(cmbLoaiMay.SelectedValue.ToString());
            ltct.IdCarddohoa = Convert.ToInt32(cmbCard.SelectedValue.ToString());
            ltct.IdHang = Convert.ToInt32(cmbHang.SelectedValue.ToString());
            ltct.IdOcung = Convert.ToInt32(cmbOCung.SelectedValue.ToString());
            ltct.IdPin = Convert.ToInt32(cmbPin.SelectedValue.ToString());
            ltct.IdRam = Convert.ToInt32(cmbRam.SelectedValue.ToString());
            ltct.IdChip = Convert.ToInt32(cmbChip.SelectedValue.ToString());
            ltct.TrangThai = true;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = LapTopCTService.AddNew(ltct);
                if (add)
                {
                    MessageBox.Show("Thêm mới thành công!");

                    Nhaphangchitiet nhct = new Nhaphangchitiet();
                    nhct.Gianhap = Convert.ToDecimal(txtGiaNhap.Text);
                    nhct.IdNhaphang = idhd;
                    nhct.Imel = txtImel.Text;
                    bool add1 = serviceCT.AddNew(nhct);//yêu cầu sửa id ng nhập từ 0 => ?

                    if (add1)
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
                    MessageBox.Show("Lỗi khi thêm mới.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối thêm mới.");
            }
            loadGridViewNhapKhoCT();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtgNhapKhoCT_CellClick(object sender, DataGridViewCellEventArgs e)
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
                IdHDCT = Convert.ToInt32(dtgNhapKhoCT.Rows[rowIndex].Cells[1].Value.ToString());
                Imel = dtgNhapKhoCT.Rows[rowIndex].Cells[2].Value.ToString();
            }

            loadLapTopCT(Imel);
        }

        private void dtgNhapKhoCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                IdHDCT = Convert.ToInt32(dtgNhapKhoCT.Rows[rowIndex].Cells[1].Value.ToString());
                Imel = dtgNhapKhoCT.Rows[rowIndex].Cells[2].Value.ToString();
            }

            loadLapTopCT(Imel);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {

            Nhaphang nh = service.GetOne(idhd);
            nh.Ngaynhap = TimPicPhieuNhap.Value;
            nh.Nhacungcap = txtNhaCC.Text;
            nh.Ghichu = txtGhiChu.Text;
            nh.Soluongnhhap = serviceCT.GetByInt(idhd,"FK").Count;
            nh.IdTaikhoan = (int)cmbTaiKhoan.SelectedValue;

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = service.Update(nh);//yêu cầu sửa id ng nhập từ 0 => ?

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

        private void btnSuaHD_Click(object sender, EventArgs e)//btnSuaHD
        {


            Nhaphang nh = service.GetOne(idhd);
            nh.Ngaynhap = TimPicPhieuNhap.Value;
            nh.Nhacungcap = txtNhaCC.Text;
            nh.Ghichu = txtGhiChu.Text;
            nh.Soluongnhhap = serviceCT.GetByInt(idhd, "FK").Count;
            nh.IdTaikhoan = (int)cmbTaiKhoan.SelectedValue;
            MessageBox.Show(nh.Soluongnhhap.ToString());
            DialogResult result = MessageBox.Show("Bạn có muốn Sửa không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = service.Update(nh);//yêu cầu sửa id ng nhập từ 0 => ?

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

        private void btnXoaSp_HD_Click(object sender, EventArgs e)//btnXoaSp_HD
        {


            DialogResult result = MessageBox.Show("Bạn có muốn Xóa không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string imel = serviceCT.GetAll().FirstOrDefault(x => x.IdNhct == IdHDCT).Imel;
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = serviceCT.Delete(IdHDCT);//yêu cầu sửa id ng nhập từ 0 => ?

                if (add)
                {
                    MessageBox.Show("Xóa thành công!");

                    var ltct = LapTopCTService.Getone(imel);
                    ltct.TrangThai = false;
                    
                    bool add1 = LapTopCTService.Update(ltct); ;//yêu cầu sửa id ng nhập từ 0 => ?

                    if (add1)
                    {
                        MessageBox.Show("sửa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi sửa.");
                    }
                    if (hdctservice.GetAll().FirstOrDefault(x => x.Imel == imel) != null)
                    {
                        MessageBox.Show("Laptop này được bán trong hóa đơn :" + hdctservice.GetAll().FirstOrDefault(x => x.Imel == imel).IdHoadon);
                    }
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
            loadGridViewNhapKhoCT();
        }

        private void btnSuaSP_HD_Click(object sender, EventArgs e)//btnSuaSp_HD
        {
            if (txtImel.Text == null)
            {
                MessageBox.Show("nhập Imel Đi đã");
                return;
            }
            if (!Regex.IsMatch(txtGiaNhap.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("mời nhập đúng giá nhập");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn sửa không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Nhaphangchitiet NHCT = serviceCT.GetByInt(IdHDCT, "PK").FirstOrDefault(x => x.IdNhct == IdHDCT);
                var lt = LapTopCTService.Getone(NHCT.Imel);
                lt.TrangThai = false;
                LapTopCTService.Update(lt);


                NHCT.Imel = txtImel.Text;
                NHCT.Gianhap = Convert.ToDecimal(txtGiaNhap.Text);
                // Thực hiện sửa mới chỉ khi tất cả điều kiện đều đúng
                bool add = serviceCT.Update(NHCT);//yêu cầu sửa id ng nhập từ 0 => ?

                Laptopchitiet ltct = new Laptopchitiet();
                ltct.Imel = txtImel.Text;
                ltct.Gianhap = Convert.ToDecimal(txtGiaNhap.Text);
                ltct.IdLaptop = Convert.ToInt32(cmbLoaiMay.SelectedValue.ToString());
                ltct.IdCarddohoa = Convert.ToInt32(cmbCard.SelectedValue.ToString());
                ltct.IdHang = Convert.ToInt32(cmbHang.SelectedValue.ToString());
                ltct.IdOcung = Convert.ToInt32(cmbOCung.SelectedValue.ToString());
                ltct.IdPin = Convert.ToInt32(cmbPin.SelectedValue.ToString());
                ltct.IdRam = Convert.ToInt32(cmbRam.SelectedValue.ToString());
                ltct.IdChip = Convert.ToInt32(cmbChip.SelectedValue.ToString());
                ltct.TrangThai = true;
                bool add1 = LapTopCTService.AddNew(ltct);
                if (add1)
                {
                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm mới.");
                }
                loadLapTopCT(NHCT.Imel);
                if (add)
                {
                    MessageBox.Show("sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi sửa.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối sửa.");
            }
            loadGridViewNhapKhoCT();
        }

        //private void btnHuyHD_Click(object sender, EventArgs e)//btnHuyHD
        //{
        //    service.delete(idhd);
        //    MessageBox.Show(idhd.ToString());
        //    this.Close();
        //    Kho kho = new Kho(null) ;
        //    kho.XoaHD();
        //    MessageBox.Show("đã xóa xong");
        //}
    }
}
