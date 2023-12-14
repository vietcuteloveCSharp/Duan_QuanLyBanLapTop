using BUS.Service;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace GUI.View
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            _service = new LaptopServices();
            _services = new ChipServices();
            _servicesRam = new RamServices();
            _servicesSSD = new OcungServices();
            _cardServices = new CardServices();
            _pinServices = new PinServices();
            _anhServices = new AnhServices();
            InitializeComponent();
        }
        LaptopServices _service = new LaptopServices();
        ChipServices _services = new ChipServices();
        RamServices _servicesRam = new RamServices();
        OcungServices _servicesSSD = new OcungServices();
        CardServices _cardServices = new CardServices();
        PinServices _pinServices = new PinServices();
        AnhServices _anhServices = new AnhServices();
        HangSevices _hangService = new HangSevices();
        TaikhoanSevrvice TKservice = new TaikhoanSevrvice();
        int selectedId = -1;
        int idsp;
        string path = "";
        int stt = 0;
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void dtg_ShowLaptop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            img = null;
            int index = e.RowIndex;
            var selectedItem = dtg_ShowLaptop.Rows[index];
            tbt_Name.Text = selectedItem.Cells[1].Value.ToString();
            tbt_Weight.Text = selectedItem.Cells[2].Value.ToString();
            tbt_MoTa.Text = selectedItem.Cells[3].Value.ToString();
            tbt_TrangThai.Text = selectedItem.Cells[4].Value.ToString();
            idsp = (int)selectedItem.Cells[0].Value;
            loadListImg();
        }
        private void LoadData(dynamic data)
        {
            dtg_ShowLaptop.Rows.Clear();
            dtg_ShowLaptop.ColumnCount = 6;
            dtg_ShowLaptop.Columns[0].HeaderText = "IdLaptop";
            dtg_ShowLaptop.Columns[1].HeaderText = "Tên Laptop";
            dtg_ShowLaptop.Columns[2].HeaderText = "Cân Nặng";
            dtg_ShowLaptop.Columns[3].HeaderText = "Mô Tả";
            dtg_ShowLaptop.Columns[4].HeaderText = "Trạng Thái";
            dtg_ShowLaptop.Columns[5].HeaderText = "Id Hãng";
            foreach (var item in data)
            {
                dtg_ShowLaptop.Rows.Add(item.IdLt, item.Tenlaptop, item.Cannang, item.Mota, item.Trangthai, item.Idhang);
            }
        }

        private void dtg_ShowLaptop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectedItem = dtg_ShowLaptop.Rows[index];
            tbt_Name.Text = selectedItem.Cells[1].Value.ToString();
            tbt_Weight.Text = selectedItem.Cells[2].Value.ToString();
            tbt_MoTa.Text = selectedItem.Cells[3].Value.ToString();
            tbt_TrangThai.Text = selectedItem.Cells[4].Value.ToString();
            selectedId = Convert.ToInt32(selectedItem.Cells[0].Value);
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(_service.GetAllLaptop());
                LoadDataChip(_services.GetAllChip());
                LoadDataOcung(_servicesSSD.GetAllOcung());
                LoadDataRam(_servicesRam.GetAllRam());
                LoadDataCard(_cardServices.GetAllCard());
                LoadDataPin(_pinServices.GetAllPin());
                LoadAnh(_anhServices.GetAllAnh());
                loadCmbhang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadCmbhang()
        {

            List<Hang> hang = _hangService.GetAllHang();
            cmbHang.DataSource = hang;
            cmbHang.ValueMember = "IdHang";
            cmbHang.DisplayMember = "Tenhang";

            List<Laptop> LaptoList = _service.GetAllLaptop();
            cb_LT.DataSource = LaptoList;  // Fix: Use LaptoList instead of hangLaptopList
            cb_LT.DisplayMember = "Tenlaptop";
            cb_LT.ValueMember = "IdLt";


        }
        private void tbt_Weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }


        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {

                string name = tbt_Name.Text;
                double canNang = double.Parse(tbt_Weight.Text);
                string mota = tbt_MoTa.Text;
                string trangThai = tbt_TrangThai.Text;
                int Idhang = int.Parse(cmbHang.SelectedValue.ToString());
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(mota) || string.IsNullOrEmpty(trangThai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }
                DialogResult = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {


                    bool add = _service.AddNewLaptop(name, canNang, mota, trangThai, Idhang);
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
                LoadData(_service.GetAllLaptop());
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi chung nếu có lỗi khác
                MessageBox.Show($"Lỗi khi thêm mới: {ex.ToString()}");
            }
        }


        private void tbt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa không?",
              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool delete = _service.DeleteLaptop(selectedId);
                if (delete)
                {
                    MessageBox.Show("xóa thành công");
                    tbt_Name.Text = string.Empty;
                    tbt_Weight.Text = string.Empty;
                    tbt_MoTa.Text = string.Empty;
                    tbt_TrangThai.Text = string.Empty;
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
            LoadData(_service.GetAllLaptop());
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = tbt_Name.Text;
            double canNang = double.Parse(tbt_Weight.Text);
            string mota = tbt_MoTa.Text;
            string trangThai = tbt_TrangThai.Text;
            int Idhang = int.Parse(cmbHang.SelectedValue.ToString());
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _service.UpdateLaptop(Id, name, canNang, mota, trangThai, Idhang);
                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadData(_service.GetAllLaptop());
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                tbt_Name.Text = string.Empty;
                tbt_Weight.Text = string.Empty;
                tbt_MoTa.Text = string.Empty;
                tbt_TrangThai.Text = string.Empty;
                cmbHang.SelectedValue = null;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }

        private void tbt_Search_TextChanged(object sender, EventArgs e)
        {
            LoadData(_service.GetLaptopByAll(tbt_Search.Text));
        }
        private void LoadDataChip(dynamic data)
        {
            dtg_ShowChip.Rows.Clear();
            dtg_ShowChip.ColumnCount = 3;
            dtg_ShowChip.Columns[0].HeaderText = "Id Chip";
            dtg_ShowChip.Columns[1].HeaderText = "Tên Chip";
            dtg_ShowChip.Columns[2].HeaderText = "Trạng Thái";
            foreach (var item in data)
            {
                dtg_ShowChip.Rows.Add(item.IdChip, item.Tenchip, item.Trangthai);
            }
        }

        private void dtg_ShowChip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectedItem = dtg_ShowChip.Rows[index];
            tbt_NameChip.Text = selectedItem.Cells[1].Value.ToString();
            tbt_TTChip.Text = selectedItem.Cells[2].Value.ToString();
            selectedId = Convert.ToInt32(selectedItem.Cells[0].Value);
        }

        private void dtg_ShowChip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectedItem = dtg_ShowChip.Rows[index];
            tbt_NameChip.Text = selectedItem.Cells[1].Value.ToString();
            tbt_TTChip.Text = selectedItem.Cells[2].Value.ToString();
        }

        private void btn_AddChip_Click(object sender, EventArgs e)
        {
            string name = tbt_NameChip.Text;
            string trangThai = tbt_TTChip.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }
            DialogResult = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _services.AddNewChip(name, trangThai);
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
            LoadDataChip(_services.GetAllChip());
        }

        //private void btn_DeleteChip_Click(object sender, EventArgs e)
        //{
        //    DialogResult = MessageBox.Show("Bạn có muốn xóa không?",
        //        "Thông báo",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Question);
        //    if (DialogResult == DialogResult.Yes)
        //    {
        //        bool delete = _services.DeleteChip(selectedId);
        //        if (delete)
        //        {
        //            MessageBox.Show("xóa thành công");
        //            tbt_NameChip.Text = string.Empty;
        //            tbt_TTChip.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa thất bại");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Từ chối xóa");
        //    }
        //    LoadDataChip(_services.GetAllChip());
        //}

        private void btn_UpdateChip_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = tbt_NameChip.Text;
            string trangThai = tbt_TTChip.Text;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _services.UpdateChip(Id, name, trangThai);
                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadDataChip(_services.GetAllChip());
        }

        private void btn_ClearChip_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
             "Thông báo",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                tbt_NameChip.Text = string.Empty;
                tbt_TTChip.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }

        private void tbt_SearchChip_TextChanged(object sender, EventArgs e)
        {
            LoadData(_services.GetChipByAll(tbt_SearchChip.Text));
        }
        public void LoadDataRam(dynamic data)
        {
            dtg_ShowRam.Rows.Clear();
            dtg_ShowRam.ColumnCount = 4;
            dtg_ShowRam.Columns[0].HeaderText = "Id Ram";
            dtg_ShowRam.Columns[1].HeaderText = "Tên Ram";
            dtg_ShowRam.Columns[2].HeaderText = "BUS";
            dtg_ShowRam.Columns[3].HeaderText = "Trạng Thái";
            foreach (var item in data)
            {
                dtg_ShowRam.Rows.Add(item.IdRam, item.Tenram, item.Bus, item.Trangthai);
            }
        }

        private void dtg_ShowRam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowRam.Rows[index];
            tbt_NameRam.Text = selected.Cells[1].Value.ToString();
            tbt_BusRam.Text = selected.Cells[2].Value.ToString();
            tbt_TTRam.Text = selected.Cells[3].Value.ToString();
            selectedId = Convert.ToInt32(selected.Cells[0].Value);
        }

        private void dtg_ShowRam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowRam.Rows[index];
            tbt_NameRam.Text = selected.Cells[1].Value.ToString();
            tbt_BusRam.Text = selected.Cells[2].Value.ToString();
            tbt_TTRam.Text = selected.Cells[3].Value.ToString();
        }

        private void btn_AddRam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbt_NameRam.Text) || string.IsNullOrEmpty(tbt_TTRam.Text) || !Regex.IsMatch(tbt_BusRam.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            string name = tbt_NameRam.Text;
            int bus = int.Parse(tbt_BusRam.Text);
            string trangThai = tbt_TTRam.Text;
            DialogResult = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _servicesRam.AddNewRam(name, bus, trangThai);
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
            LoadDataRam(_servicesRam.GetAllRam());
        }

        //private void btn_DeleteRam_Click(object sender, EventArgs e)
        //{
        //    DialogResult = MessageBox.Show("Bạn có muốn xóa không?",
        //       "Thông báo",
        //       MessageBoxButtons.YesNo,
        //       MessageBoxIcon.Question);
        //    if (DialogResult == DialogResult.Yes)
        //    {
        //        bool delete = _servicesRam.DeleteRam(selectedId);
        //        if (delete)
        //        {
        //            MessageBox.Show("xóa thành công");
        //            tbt_NameRam.Text = string.Empty;
        //            tbt_BusRam.Text = string.Empty;
        //            tbt_TTRam.Text = string.Empty;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Xóa thất bại");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Từ chối xóa");
        //    }
        //    LoadDataRam(_servicesRam.GetAllRam());
        //}

        private void btn_UpdateRam_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = tbt_NameRam.Text;
            int bus = int.Parse(tbt_BusRam.Text);
            string trangThai = tbt_TTRam.Text;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _servicesRam.UpdateRam(Id, name, bus, trangThai);
                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadDataRam(_servicesRam.GetAllRam());
        }

        private void tbt_SearchRam_TextChanged(object sender, EventArgs e)
        {
            LoadData(_servicesRam.GetRamByAll(tbt_SearchRam.Text));
        }

        private void btn_ClearRam_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                tbt_NameRam.Text = string.Empty;
                tbt_BusRam.Text = string.Empty;
                tbt_TTRam.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }
        private void LoadDataOcung(dynamic data)
        {
            dtg_ShowSSD.Rows.Clear();
            dtg_ShowSSD.ColumnCount = 4;
            dtg_ShowSSD.Columns[0].HeaderText = "Id Ổ Cứng";
            dtg_ShowSSD.Columns[1].HeaderText = "Dung Lượng";
            dtg_ShowSSD.Columns[2].HeaderText = "Tên Ổ Cứng";
            dtg_ShowSSD.Columns[3].HeaderText = "Loại";
            foreach (var item in data)
            {
                dtg_ShowSSD.Rows.Add(item.IdOcung, item.Dungluong, item.Tenocung, item.Loai);
            }
        }

        private void dtg_ShowSSD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowSSD.Rows[index];
            tbt_DungLuong.Text = selected.Cells[1].Value.ToString();
            tbt_TenSSD.Text = selected.Cells[2].Value.ToString();
            tbt_LoaiSSD.Text = selected.Cells[3].Value.ToString();
            selectedId = Convert.ToInt32(selected.Cells[0].Value);
        }

        private void dtg_ShowSSD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowSSD.Rows[index];
            tbt_DungLuong.Text = selected.Cells[1].Value.ToString();
            tbt_TenSSD.Text = selected.Cells[2].Value.ToString();
            tbt_LoaiSSD.Text = selected.Cells[3].Value.ToString();
        }

        private void btn_AddSSD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbt_TenSSD.Text) || string.IsNullOrEmpty(tbt_LoaiSSD.Text) || !Regex.IsMatch(tbt_DungLuong.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            int dungLuong = int.Parse(tbt_DungLuong.Text);
            string name = tbt_TenSSD.Text;
            string loai = tbt_LoaiSSD.Text;
            DialogResult = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _servicesSSD.AddNewOcung(dungLuong, name, loai);
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
            LoadDataOcung(_servicesSSD.GetAllOcung());
        }

        private void btn_UpdateSSD_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            int dungLuong = int.Parse(tbt_DungLuong.Text);
            string name = tbt_TenSSD.Text;
            string loai = tbt_LoaiSSD.Text;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _servicesSSD.UpdateOcung(Id, dungLuong, name, loai);
                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadDataOcung(_servicesSSD.GetAllOcung());
        }

        private void tbt_SearchSDD_TextChanged(object sender, EventArgs e)
        {
            LoadDataOcung(_servicesSSD.GetOcungByAll(tbt_SearchSSD.Text));
        }

        private void btn_ClearSSD_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                tbt_DungLuong.Text = string.Empty;
                tbt_TenSSD.Text = string.Empty;
                tbt_LoaiSSD.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }
        private void LoadDataCard(dynamic data)
        {
            dtg_ShowCard.Rows.Clear();
            dtg_ShowCard.ColumnCount = 4;
            dtg_ShowCard.Columns[0].HeaderText = "Id Card";
            dtg_ShowCard.Columns[1].HeaderText = "Tên Card";
            dtg_ShowCard.Columns[2].HeaderText = "Dung Lượng";
            dtg_ShowCard.Columns[3].HeaderText = "Trạng Thái";
            foreach (var item in data)
            {
                dtg_ShowCard.Rows.Add(item.IdCarddohoa, item.Tencard, item.Dungluong, item.Trangthai);
            }
        }

        private void dtg_ShowCard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowCard.Rows[index];
            tbt_NameCard.Text = selected.Cells[1].Value.ToString();
            tbt_DungLuongCard.Text = selected.Cells[2].Value.ToString();
            tbt_TTCard.Text = selected.Cells[3].Value.ToString();
            selectedId = Convert.ToInt32(selected.Cells[0].Value);
        }

        private void dtg_ShowCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowCard.Rows[index];
            tbt_NameCard.Text = selected.Cells[1].Value.ToString();
            tbt_DungLuongCard.Text = selected.Cells[2].Value.ToString();
            tbt_TTCard.Text = selected.Cells[3].Value.ToString();
        }

        private void btn_AddCard_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbt_NameCard.Text) || string.IsNullOrEmpty(tbt_TTCard.Text) || !Regex.IsMatch(tbt_DungLuongCard.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            string name = tbt_NameCard.Text;
            int dungLuong = int.Parse(tbt_DungLuongCard.Text);
            string trangThai = tbt_TTCard.Text;
            DialogResult = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _cardServices.AddNewCard(name, dungLuong, trangThai);
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
            LoadDataCard(_cardServices.GetAllCard());
        }

        private void tbt_DungLuongCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_UpdateCard_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = tbt_NameCard.Text;
            int dungLuong = int.Parse(tbt_DungLuongCard.Text);
            string trangThai = tbt_TTCard.Text;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _cardServices.UpdateCard(Id, name, dungLuong, trangThai);
                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadDataCard(_cardServices.GetAllCard());
        }

        private void btn_ClearCard_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                tbt_NameCard.Text = string.Empty;
                tbt_DungLuongCard.Text = string.Empty;
                tbt_TTCard.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }

        private void tbt_SearchCard_TextChanged(object sender, EventArgs e)
        {
            LoadData(_cardServices.GetCardByAll(tbt_SearchCard.Text));
        }
        private void LoadDataPin(dynamic data)
        {
            dtg_ShowPin.Rows.Clear();
            dtg_ShowPin.ColumnCount = 6;
            dtg_ShowPin.Columns[0].HeaderText = "Id Hãng";
            dtg_ShowPin.Columns[1].HeaderText = "Tên Pin";
            dtg_ShowPin.Columns[2].HeaderText = "Dung Lượng";
            dtg_ShowPin.Columns[3].HeaderText = "Loại Pin";
            dtg_ShowPin.Columns[4].HeaderText = "Thời Gian Sử Dụng";
            dtg_ShowPin.Columns[5].HeaderText = "Trạng Thái";
            foreach (var item in data)
            {
                dtg_ShowPin.Rows.Add(item.IdPin, item.Tenpin, item.Dungluong, item.Loaipin, item.Thoigiansd, item.Trangthai);
            }
        }

        private void dtg_ShowPin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowPin.Rows[index];
            tbt_NamePin.Text = selected.Cells[1].Value.ToString();
            tbt_DLPin.Text = selected.Cells[2].Value.ToString();
            tbt_LoaiPin.Text = selected.Cells[3].Value.ToString();
            tbt_TimeDung.Text = selected.Cells[4].Value.ToString();
            tbt_TTPin.Text = selected.Cells[5].Value.ToString();
            selectedId = Convert.ToInt32(selected.Cells[0].Value);
        }

        private void dtg_ShowPin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowPin.Rows[index];
            tbt_NamePin.Text = selected.Cells[1].Value.ToString();
            tbt_DLPin.Text = selected.Cells[2].Value.ToString();
            tbt_LoaiPin.Text = selected.Cells[3].Value.ToString();
            tbt_TimeDung.Text = selected.Cells[4].Value.ToString();
            tbt_TTPin.Text = selected.Cells[5].Value.ToString();
        }

        private void btn_AddPin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbt_NamePin.Text) || string.IsNullOrEmpty(tbt_LoaiPin.Text) || string.IsNullOrEmpty(tbt_TTPin.Text) || !Regex.IsMatch(tbt_DLPin.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            string name = tbt_NamePin.Text;
            int dungLuong = int.Parse(tbt_DLPin.Text);
            string loaiPin = tbt_LoaiPin.Text;
            int han = int.Parse(tbt_TimeDung.Text);
            string trangThai = tbt_TTPin.Text;
            DialogResult = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _pinServices.AddNewPin(name, dungLuong, loaiPin, han, trangThai);
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
            LoadDataPin(_pinServices.GetAllPin());
        }

        private void btn_UpdatePin_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = tbt_NamePin.Text;
            int dungLuong = int.Parse(tbt_DLPin.Text);
            string loaiPin = tbt_LoaiPin.Text;
            int han = int.Parse(tbt_TimeDung.Text);
            string trangThai = tbt_TTPin.Text;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _pinServices.UpdatePin(Id, name, dungLuong, loaiPin, han, trangThai);
                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadDataPin(_pinServices.GetAllPin());
        }

        private void btn_ClearPin_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                tbt_NamePin.Text = string.Empty;
                tbt_DLPin.Text = string.Empty;
                tbt_LoaiPin.Text = string.Empty;
                tbt_TimeDung.Text = string.Empty;
                tbt_TTPin.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }

        private void tbt_SearchPin_TextChanged(object sender, EventArgs e)
        {
            LoadDataPin(_pinServices.GetPinByAll(tbt_SearchPin.Text));
        }
        private void LoadAnh(dynamic data)
        {
            dtg_ShowAnh.Rows.Clear();
            dtg_ShowAnh.ColumnCount = 5;
            dtg_ShowAnh.Columns[0].HeaderText = "Id Ảnh";
            dtg_ShowAnh.Columns[1].HeaderText = "Tên SRC";
            dtg_ShowAnh.Columns[2].HeaderText = "người Tạo";
            dtg_ShowAnh.Columns[3].HeaderText = "Ngày Tạo";
            dtg_ShowAnh.Columns[4].HeaderText = "Id Laptop";
            foreach (var item in data)
            {
                var lt = _service.GetAllLaptop().FirstOrDefault(x => x.IdLt == item.Idlaptop);

                dtg_ShowAnh.Rows.Add(item.IdHinhanh, item.Src, item.Nguoitao, item.Ngaytao, lt.Tenlaptop);
            }
        }

        private void dtg_ShowAnh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowAnh.Rows[index];
            pcb_Anh.Image = Image.FromFile(selected.Cells[1].Value.ToString());
            txtNguoiTao.Text = selected.Cells[2].Value.ToString();
            dt_NgayTao.Value = DateTime.Parse(selected.Cells[3].Value.ToString());
            cb_LT.Text = selected.Cells[4].Value.ToString();
            selectedId = Convert.ToInt32(selected.Cells[0].Value);
        }

        private void dtg_ShowAnh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowAnh.Rows[index];
            pcb_Anh.Image = Image.FromFile(selected.Cells[1].Value.ToString());
            txtNguoiTao.Text = selected.Cells[2].Value.ToString();
            dt_NgayTao.Value = DateTime.Parse(selected.Cells[3].Value.ToString());
            cb_LT.SelectedIndex = int.Parse(selected.Cells[4].Value.ToString());
        }
        byte[] ConvertAnhToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ConvertByArray(byte[] array)
        {
            using (MemoryStream ms = new MemoryStream(array))
            {
                return Image.FromStream(ms);
            }
        }



        private void btn_AddAnh_Click(object sender, EventArgs e)
        {
            string name = path;
            string nguoiTao = txtNguoiTao.Text;
            DateTime ngayTao = dt_NgayTao.Value;
            int idLap = int.Parse(cb_LT.SelectedValue.ToString());
            DialogResult = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _anhServices.AddNewAnh(name, nguoiTao, ngayTao, idLap);
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
            LoadAnh(_anhServices.GetAllAnh());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Please select an image file to encrypt.";
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;...";
            open.ShowDialog();

            if (!string.IsNullOrEmpty(open.FileName))
            {
                Image originalImage = Image.FromFile(open.FileName);
                pcb_Anh.SizeMode = PictureBoxSizeMode.Zoom;
                float scaleFactor = Math.Min((float)pcb_Anh.Width / originalImage.Width, (float)pcb_Anh.Height / originalImage.Height);
                int newWidth = (int)(originalImage.Width * scaleFactor);
                int newHeight = (int)(originalImage.Height * scaleFactor);
                Bitmap scaledImage = new Bitmap(originalImage, newWidth, newHeight);
                pcb_Anh.Image = scaledImage;
                path = open.FileName;
            }
        }

        private void SanPham_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_UpdateAnh_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = path;
            string nguoiTao = txtNguoiTao.Text;
            DateTime ngayTao = dt_NgayTao.Value;
            int idLap = int.Parse(cb_LT.SelectedValue.ToString());
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _anhServices.UpdateAnh(Id, name, nguoiTao, ngayTao, idLap);
                if (add)
                {
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi Sửa");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadAnh(_anhServices.GetAllAnh());
        }

        private void btn_ClearAnh_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                txtNguoiTao.Text = string.Empty;
                dt_NgayTao.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }
        private List<string> img;
        private void loadListImg()
        {
            foreach (var item in _anhServices.GetAnhByIDLT(idsp))
            {
                img.Add(item.Src.ToString());
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //private void btnnext_Click(object sender, EventArgs e)
        //{
        //    stt++;
        //    if (stt > img.Count - 1)
        //    {
        //        stt = 0;
        //    }
        //    string imgnow = img[stt];
        //    pictureBox1.Image = Image.FromFile(imgnow);
        //}

        //private void btnprev_Click(object sender, EventArgs e)
        //{

        //    stt--;
        //    if (stt < 0)
        //    {
        //        stt = img.Count - 1;
        //    }
        //    string imgnow = img[stt];
        //    pictureBox1.Image = Image.FromFile(imgnow);
        //}

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();

            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            tp_Hang.Controls.Add(childForm);
            tp_Hang.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void guna2TabControl1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Hang1());
            tp_Hang.Text = tb_hang.Text;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tp_Hang_Click(object sender, EventArgs e)
        {

        }
        //public void loadAnhLT(int id)
        //{
        //    int stt = 1;
        //    List<Image> img;
        //    if (_anhServices.GetAnhByIDLT(id) == null)
        //    {

        //    }
        //    foreach (var item in _anhServices.GetAnhByIDLT(id))
        //    {
        //        img.Add(Image.FromFile(item.Src));
        //    }
        //}
    }
}
