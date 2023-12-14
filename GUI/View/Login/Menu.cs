using BUS.Service;
using BUS.LoginService;
using DAL.DomainClass;
using DAL.Repository;
using GUI.View;
using System.Security.Cryptography;


namespace GUI
{
    public partial class Menu : Form
    {
        private Taikhoan _taiKhoan;
        LoginService _loginService = new LoginService();
        public Menu(Taikhoan taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
            lb_TenTK.Text = _taiKhoan.Hoten;
            if (_taiKhoan.IdPhanquyen == 1)
            {
                btn_Nhansu.Visible = true;
            }
            else
            {
                btn_Nhansu.Visible = false;
            }


        }



        private void Form1_Load(object sender, EventArgs e)
        {

            lb_Time.Text = DateTime.Now.ToShortDateString();

        }



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
            pl_Menu.Controls.Add(childForm);
            pl_Menu.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btn_Nhansu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
            lb_Menu.Text = btn_Nhansu.Text;
        }


        private void lb_TTTK_Click(object sender, EventArgs e)
        {
            string username = _taiKhoan.Username;

            Taikhoan taiKhoan = _loginService.GetTaiKhoanByUsername(username);

            if (taiKhoan != null)
            {
                // Tạo một thể hiện của TTCT và chuyển thông tin tài khoản
                TTTK ttctForm = new TTTK(taiKhoan);
                ttctForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lb_DoiMK_Click(object sender, EventArgs e)
        {
            string username = _taiKhoan.Username;
            DoiMK doiMKForm = new DoiMK(username);
            doiMKForm.Show();

        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe());
            lb_Menu.Text = btn_ThongKe.Text;
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HoaDon(_taiKhoan.IdTaikhoan));
            lb_Menu.Text = btn_HoaDon.Text;
        }

        private void btn_NhapKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Kho(_taiKhoan.IdTaikhoan));
            lb_Menu.Text = btn_NhapKho.Text;
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
            this.Hide();
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SanPham());
            lb_Menu.Text = btn_SanPham.Text;

        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHang());
            lb_Menu.Text = btn_KhachHang.Text;
        }
    }
}