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

namespace GUI.View
{
    public partial class TTTK : Form
    {
        private Taikhoan _taiKhoan;
        public TTTK(Taikhoan taiKhoan)
        {
            InitializeComponent();


            _taiKhoan = taiKhoan;
            
            ptb_IMGNV.Image = Image.FromFile(_taiKhoan.Hinhanh.ToString());
               

            lb_Ten.Text = _taiKhoan.Hoten.ToString();
            lb_DiaChi.Text = _taiKhoan.Diachi.ToString();
            lb_Email.Text = _taiKhoan.Email.ToString();
            lb_SoDT.Text = _taiKhoan.Dienthoai.ToString();
            lb_NgaySinh.Text = _taiKhoan.Ngaysinh.ToShortDateString();
        }

    }
}
