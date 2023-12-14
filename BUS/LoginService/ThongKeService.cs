using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;

namespace BUS.Service
{
    public class ThongKeService
    {
        ThongKeRepo _thongKeRepo;

        public ThongKeService()
        {
            _thongKeRepo = new ThongKeRepo();
        }

        public int GetSoLuongSanPhamBanTrongNgay(DateTime ngay)
        {
            return _thongKeRepo.GetSoLuongSanPhamBanTrongNgay(ngay);
        }

        public decimal GetDoanhThuTrongNgay(DateTime ngay)
        {
            return _thongKeRepo.GetDoanhThuTrongNgay(ngay);
        }

        public int GetSoLuongKhachHangTrongNgay(DateTime ngay)
        {
            return _thongKeRepo.GetSoLuongKhachHangTrongNgay(ngay);
        }

        public List<Hoadon> GetHoadonsInTimeRange(DateTime fromTime, DateTime toTime)
        {
            return _thongKeRepo.GetHoadonsInTimeRange(fromTime, toTime);
        }
        public decimal GetTongTienInTimeRange(DateTime fromTime, DateTime toTime)
        {
            return _thongKeRepo.GetTongTienInTimeRange(fromTime, toTime);
        }

        public List<Hoadon> GetHoadons()
        {
            return _thongKeRepo.GetHoadons().Where(x => x.Trangthai == true).ToList();
        }
        public List<Hoadonct> GetHoadoncts()
        {
            return _thongKeRepo.GetHoadoncts().ToList();
        }

        public int GetTotalActiveImelsCount()
        {
            return _thongKeRepo.GetTotalActiveImelsCount();
        }
    }
}
