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


namespace GUI.View
{
    public partial class ThongKe : Form
    {
        ThongKeService thongKeService = new ThongKeService();
        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            DateTime ngayHienTai = DateTime.Now;
            lb_TonKho.Text = thongKeService.GetTotalActiveImelsCount().ToString();
            lb_SLBan.Text = thongKeService.GetSoLuongSanPhamBanTrongNgay(ngayHienTai).ToString();
            lb_DoanhThuNgay.Text = thongKeService.GetDoanhThuTrongNgay(ngayHienTai).ToString(); ;
            lb_SoKHMua.Text = thongKeService.GetSoLuongKhachHangTrongNgay(ngayHienTai).ToString(); ;
            LoaData(thongKeService.GetHoadons());
        }

        public void LoaData(dynamic data)
        {
            dtg_Load.Rows.Clear();
            dtg_Load.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int stt = 1;
            dtg_Load.ColumnCount = 5;
            dtg_Load.Columns[0].Name = "Stt";
            dtg_Load.Columns[1].Name = "Mã hóa đơn";
            dtg_Load.Columns[2].Name = "Ngày mua";
            dtg_Load.Columns[3].Name = "Số Lượng";
            dtg_Load.Columns[4].Name = "Giá tiền";

            foreach (var c in data)
            {
                var hdct = thongKeService.GetHoadoncts().Where(x => x.IdHoadon == c.IdHoadon).ToList();

                dtg_Load.Rows.Add(stt++, c.IdHoadon, c.Ngaymua, hdct.Count(), c.Tongtien);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem thời điểm kết thúc có lớn hơn thời điểm bắt đầu không
            if (time_To.Value >= time_From.Value)
            {
                // Gọi phương thức để tìm kiếm theo ngày và cập nhật DataGridView
                LoaData(thongKeService.GetHoadonsInTimeRange(time_From.Value, time_To.Value));

                // Lấy và hiển thị tổng tiền
                decimal tongTien = thongKeService.GetTongTienInTimeRange(time_From.Value, time_To.Value);
                lb_TongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VND";
            }
            else
            {
                // Hiển thị thông báo lỗi nếu thời điểm kết thúc không hợp lệ
                MessageBox.Show("Thời điểm kết thúc phải lớn hơn hoặc bằng thời điểm bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
