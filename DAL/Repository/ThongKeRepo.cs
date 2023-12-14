using DAL.Context;
using DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ThongKeRepo
    {
        DBContext db;

        public ThongKeRepo()
        {
            db = new DBContext();
        }

        public List<Hoadon> GetHoadons()
        {
            return db.Hoadons.ToList();
        }
        public List<Hoadonct> GetHoadoncts()
        {
            return db.Hoadoncts.ToList();
        }
        public int GetSoLuongSanPhamBanTrongNgay(DateTime ngay)
        {
            int soLuong = db.Hoadoncts
                .Where(hdct => hdct.IdHoadonNavigation.Ngaymua.Date == ngay.Date && hdct.IdHoadonNavigation.Trangthai == true)
                .Select(hdct => hdct.ImelNavigation)
                .Where(imel => imel != null)
                .Select(imel => imel.Imel)
                .Distinct()
                .Count();

            return soLuong;
        }

        public decimal GetDoanhThuTrongNgay(DateTime ngay)
        {
            decimal doanhThu = db.Hoadoncts
                .Where(hdct => hdct.IdHoadonNavigation.Ngaymua.Date == ngay.Date && hdct.IdHoadonNavigation.Trangthai == true)
                .Sum(hdct => hdct.Gia);

            return doanhThu;
        }

        public int GetSoLuongKhachHangTrongNgay(DateTime ngay)
        {
            int soLuong = db.Hoadoncts
                .Where(hdct => hdct.IdHoadonNavigation.Ngaymua.Date == ngay.Date && hdct.IdHoadonNavigation.Trangthai == true)
                .Select(hdct => hdct.IdHoadonNavigation.IdKhachhang)
                .Distinct()
                .Count();

            return soLuong;
        }

        // Các phương thức khác cần thiết cho thống kê

        // Ví dụ phương thức lấy danh sách hóa đơn trong khoảng thời gian
        public List<Hoadon> GetHoadonsInTimeRange(DateTime fromTime, DateTime toTime)
        {
            return db.Hoadons
                .Where(hd => hd.Ngaymua >= fromTime && hd.Ngaymua <= toTime && hd.Trangthai == true)
                .ToList();
        }
        public decimal GetTongTienInTimeRange(DateTime fromTime, DateTime toTime)
        {
            decimal tongTien = db.Hoadons
                .Where(hd => hd.Ngaymua >= fromTime && hd.Ngaymua <= toTime)
                .Sum(hd => hd.Tongtien);

            return tongTien;
        }
        public int GetTotalActiveImelsCount()
        {
            int totalImels = db.Laptopchitiets
                .Count(lc => lc.TrangThai==true);

            return totalImels;
        }
    }
}
