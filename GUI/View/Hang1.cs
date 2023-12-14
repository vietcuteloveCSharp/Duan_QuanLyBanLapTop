using BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI.View
{
    public partial class Hang1 : Form
    {
        public Hang1()
        {
            _services = new HangSevices();
            InitializeComponent();
        }
        HangSevices _services = new HangSevices();
        int selectedId = -1;
        private void LoadData(dynamic data)
        {
            dtg_ShowHang.Rows.Clear();
            dtg_ShowHang.ColumnCount = 3;
            dtg_ShowHang.Columns[0].HeaderText = "Id Hãng";
            dtg_ShowHang.Columns[1].HeaderText = "Tên Hãng";
            dtg_ShowHang.Columns[2].HeaderText = "Trạng Thái";
            foreach (var item in data)
            {
                dtg_ShowHang.Rows.Add(item.IdHang, item.Tenhang, item.Trangthai);
            }
        }

        private void dtg_ShowHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowHang.Rows[index];
            tbt_Name.Text = selected.Cells[1].Value.ToString();
            tbt_TrangThai.Text = selected.Cells[2].Value.ToString();
            selectedId = Convert.ToInt32(selected.Cells[0].Value);
        }

        private void dtg_ShowHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var selected = dtg_ShowHang.Rows[index];
            tbt_Name.Text = selected.Cells[1].Value.ToString();
            tbt_TrangThai.Text = selected.Cells[2].Value.ToString();
        }

        private void Hang_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData(_services.GetAllHang());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string name = tbt_Name.Text;
            string trangThai = tbt_TrangThai.Text;
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
                bool add = _services.AddNewHang(name, trangThai);
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
            LoadData(_services.GetAllHang());
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn xóa không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool delete = _services.DeleteHang(selectedId);
                if (delete)
                {
                    MessageBox.Show("xóa thành công");
                    tbt_Name.Text = string.Empty;
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
            LoadData(_services.GetAllHang());
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int Id = selectedId;
            string name = tbt_Name.Text;
            string trangThai = tbt_TrangThai.Text;
            DialogResult = MessageBox.Show("Bạn có muốn sửa không?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                bool add = _services.UpdateHang(Id, name, trangThai);
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
            LoadData(_services.GetAllHang());
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
                tbt_TrangThai.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Từ chối xóa!");
            }
        }

        private void tbt_Search_TextChanged(object sender, EventArgs e)
        {
            LoadData(_services.GetHangByAll(tbt_Search.Text));
        }
    }
}
