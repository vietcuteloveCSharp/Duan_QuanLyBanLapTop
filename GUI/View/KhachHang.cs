using BUS.Service;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI.View
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            _service = new KhachHangServices();
            InitializeComponent();
        }
        KhachHangServices _service = new KhachHangServices();
        int selectedId = -1;
        private void LoadData(dynamic data)
        {
            dtg_ShowKH.Rows.Clear();
            dtg_ShowKH.ColumnCount = 5;
            dtg_ShowKH.Columns[0].HeaderText = "IdKH";
            dtg_ShowKH.Columns[1].HeaderText = "Tên KH";
            dtg_ShowKH.Columns[2].HeaderText = "Địa Chỉ";
            dtg_ShowKH.Columns[3].HeaderText = "Số Điện Thoại";
            dtg_ShowKH.Columns[4].HeaderText = "Email";
            foreach (var item in data)
            {
                dtg_ShowKH.Rows.Add(item.IdKhachhang, item.Tenkh, item.Diachi, item.Dienthoai, item.Email);
            }
        }

        private void dtg_ShowKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectedItem = dtg_ShowKH.Rows[index];
            tbt_Name.Text = selectedItem.Cells[1].Value.ToString();
            tbt_Address.Text = selectedItem.Cells[2].Value.ToString();
            tbt_Phone.Text = selectedItem.Cells[3].Value.ToString();
            tbt_Email.Text = selectedItem.Cells[4].Value.ToString();
            selectedId = Convert.ToInt32(selectedItem.Cells[0].Value);
        }

        private void dtg_ShowKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectedItem = dtg_ShowKH.Rows[index];
            tbt_Name.Text = selectedItem.Cells[1].Value.ToString();
            tbt_Address.Text = selectedItem.Cells[2].Value.ToString();
            tbt_Phone.Text = selectedItem.Cells[3].Value.ToString();
            tbt_Email.Text = selectedItem.Cells[4].Value.ToString();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(_service.GetAllKH());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)//btnThem_Click
        {
            string name = tbt_Name.Text;
            string diaChi = tbt_Address.Text;
            string sdt = tbt_Phone.Text;
            string email = tbt_Email.Text;

            // Kiểm tra điều kiện đầy đủ thông tin
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra số điện thoại và email
            if (!IsValidPhoneNumber(sdt) || !IsValidEmail(email))
            {
                MessageBox.Show("Không đúng định dạng số điện thoại hoặc email.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn thêm mới không?", "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện thêm mới chỉ khi tất cả điều kiện đều đúng
                bool add = _service.AddNewKH(name, diaChi, sdt, email);

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

            LoadData(_service.GetAllKH());
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {

            if (phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10)
            {
                return phoneNumber.Length == 0 || phoneNumber.StartsWith("0");
            }

            return false;
        }
        private bool IsValidEmail(string email)
        {
            return email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool delete = _service.DeleteKH(selectedId);
                if (delete)
                {
                    MessageBox.Show("xóa thành công");
                    tbt_Name.Text = string.Empty;
                    tbt_Address.Text = string.Empty;
                    tbt_Phone.Text = string.Empty;
                    tbt_Email.Text = string.Empty;
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
            LoadData(_service.GetAllKH());
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = tbt_Name.Text;
            string diaChi = tbt_Address.Text;
            string sdt = tbt_Phone.Text;
            string email = tbt_Email.Text;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (IsValidPhoneNumber(sdt) && IsValidEmail(email))
                {
                    bool add = _service.UpdateKH(Id, name, diaChi, sdt, email);

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
                    MessageBox.Show("Không đúng định dạng số điện thoại hoặc email.");
                }
            }
            else
            {
                MessageBox.Show("Từ chối Sửa.");
            }
            LoadData(_service.GetAllKH());
        }

        private void txtSrearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(_service.GetKHByAll(txtSrearch.Text));
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
                tbt_Address.Text = string.Empty;
                tbt_Phone.Text = string.Empty;
                tbt_Email.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }

        
    }
}
