using BUS.Service;
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
    public partial class NhanVien : Form
    {

        TaikhoanSevrvice taikhoanSevrvice = new TaikhoanSevrvice();
        int id;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa những gì vừa nhập không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                txtAddress.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPass.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtUser.Text = string.Empty;
                dateInfo.Value = DateTime.Now;
                radio_ad.Checked = false;
                radio_nv.Checked = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }


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
            //return email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
            if (Regex.IsMatch(email, "^^[a-zA-Z0-9]+\\@+[a-z]+\\.[a-z]{2,3}(\\.[a-z]{2})?$"))
            {
                return true;
            }
            return false;
        }
        private void btn_Create_Click(object sender, EventArgs e)
        {
            Taikhoan taikhoan = new Taikhoan();
            taikhoan.TrangThai = radioButton1.Checked ? true : false;
            taikhoan.Diachi = txtAddress.Text;
            taikhoan.Dienthoai = txtPhone.Text;
            taikhoan.Email = txtEmail.Text;
            taikhoan.Hoten = txtName.Text;
            taikhoan.Hinhanh = path;
            taikhoan.Username = txtUser.Text;
            taikhoan.Password = txtPass.Text;
            taikhoan.Ngaysinh = dateInfo.Value;

            if (radio_ad.Checked == true)
            {
                taikhoan.IdPhanquyen = 1;
            }
            else
            {
                taikhoan.IdPhanquyen = 2;
            }
            taikhoan.TrangThai = true;


            // Kiểm tra điều kiện đầy đủ thông tin
            if (string.IsNullOrEmpty(taikhoan.Hoten) || string.IsNullOrEmpty(taikhoan.Diachi) || string.IsNullOrEmpty(taikhoan.Dienthoai) || string.IsNullOrEmpty(taikhoan.Email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra số điện thoại và email
            if (!IsValidPhoneNumber(taikhoan.Dienthoai) || !IsValidEmail(taikhoan.Email))
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
                bool add = taikhoanSevrvice.CreateTaiKhoan(taikhoan);

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

            LoadData(taikhoanSevrvice.Gettaikhoan());

        }
        public bool checkNull()
        {
            if (string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtUser.Text)
                || radio_ad.Checked == false || radio_nv.Checked == false || radioButton1.Checked == false || radioButton2.Checked == false)
            {
                MessageBox.Show("Không để trống các trường", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public void LoadData(List<Taikhoan> data)
        {
            DGVAccount.Rows.Clear();
            DGVAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int stt = 1;
            DGVAccount.ColumnCount = 12;
            DGVAccount.Columns[0].Name = "Stt";
            DGVAccount.Columns[1].Name = "Username";
            DGVAccount.Columns[2].Name = "Password";
            DGVAccount.Columns[3].Name = "Họ và tên ";
            DGVAccount.Columns[4].Name = "Email";
            DGVAccount.Columns[5].Name = "Sđt";
            DGVAccount.Columns[6].Name = "Địa chỉ";
            DGVAccount.Columns[7].Name = "Trang thái";
            DGVAccount.Columns[8].Name = "Quyền";
            DGVAccount.Columns[9].Name = "Ngày sinh";
            DGVAccount.Columns[10].Name = "IdTaikhoan";
            DGVAccount.Columns[11].Name = " Hình Ảnh";
            DGVAccount.Columns[10].Visible = false;
            foreach (var c in data)
            {
                var pq = taikhoanSevrvice.Getphanquyen().FirstOrDefault(x => x.IdPhanquyen == c.IdPhanquyen);

                DGVAccount.Rows.Add(stt++, c.Username, c.Password, c.Hoten, c.Email, c.Dienthoai, c.Diachi, c.TrangThai == true ? "Hoạt Động" : "Không Hoạt Động", pq.Tenquyen, c.Ngaysinh, c.IdTaikhoan, c.Hinhanh);
            }
        }
        private void DGVAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selectedItem = DGVAccount.Rows[index];
            txtUser.Text = selectedItem.Cells[1].Value.ToString();
            txtPass.Text = selectedItem.Cells[2].Value.ToString();
            txtName.Text = selectedItem.Cells[3].Value.ToString();
            txtEmail.Text = selectedItem.Cells[4].Value.ToString();
            txtPhone.Text = selectedItem.Cells[5].Value.ToString();
            txtAddress.Text = selectedItem.Cells[6].Value.ToString();
            if (selectedItem.Cells[11].Value != "")
            {

                pcb_Image.Image = Image.FromFile(selectedItem.Cells[11].Value.ToString());
            }
            else
            {
                pcb_Image.Image = null;
            }
            id = Convert.ToInt32(selectedItem.Cells[10].Value.ToString());
            txtUser.ReadOnly = true;
            txtPass.ReadOnly = true;
            radio_ad.Enabled = false;
            radio_nv.Enabled = false;

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(taikhoanSevrvice.Gettaikhoan());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

            bool trangthai = radioButton1.Checked ? true : false;
            string diaChi = txtAddress.Text;
            string sdt = txtPhone.Text;
            string email = txtEmail.Text;
            string hinhanh = path;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                if (IsValidPhoneNumber(sdt) && IsValidEmail(email))
                {
                    bool add = taikhoanSevrvice.UpdateInfo((int)id, diaChi, hinhanh, sdt, trangthai, email);
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
            LoadData(taikhoanSevrvice.Gettaikhoan());
        }

        private void txtSrearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(taikhoanSevrvice.GetTKHByAll(txtSrearch.Text));

        }
        string path = "";
        private void btn_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Please select an image file to encrypt.";
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;...";
            open.ShowDialog();
            if (!string.IsNullOrEmpty(open.FileName))
            {
                Image originalImage = Image.FromFile(open.FileName);
                pcb_Image.SizeMode = PictureBoxSizeMode.Zoom;
                float scaleFactor = Math.Min((float)pcb_Image.Width / originalImage.Width, (float)pcb_Image.Height / originalImage.Height);
                int newWidth = (int)(originalImage.Width * scaleFactor);
                int newHeight = (int)(originalImage.Height * scaleFactor);
                Bitmap scaledImage = new Bitmap(originalImage, newWidth, newHeight);
                pcb_Image.Image = scaledImage;
                path = open.FileName;
            }
        }
    }
}