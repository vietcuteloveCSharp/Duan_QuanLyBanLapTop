using DAL.DomainClass;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class TaikhoanSevrvice
    {
        TaikhoanRepo _taiKhoanRepo = new TaikhoanRepo();
        PhanquyenRepo _phanQuyenRepo = new PhanquyenRepo();
        List<Taikhoan> _lstTaiKhoan;
        List<Phanquyen> _lstPhanQuyen;
        public TaikhoanSevrvice()
        {
            _lstTaiKhoan = _taiKhoanRepo.GetTaiKhoan();
            _lstPhanQuyen  =_phanQuyenRepo.GetPhanQuyen();
        }
        public List<Taikhoan> Gettaikhoan()
        {
            return _taiKhoanRepo.GetTaiKhoan().ToList();
        }
        public List<Phanquyen> Getphanquyen()
        {
            return _phanQuyenRepo.GetPhanQuyen().ToList();
        }
        public bool CreateTaiKhoan(Taikhoan taiKhoan)
        {
            if (_taiKhoanRepo.IsEmailExists(taiKhoan.Email ,taiKhoan.Username) == true)
            {
                return false; 
            }
            return _taiKhoanRepo.AddTaikhoan(taiKhoan);
        }
        
        public bool UpdateInfo(int id, string diachi,string hinhanh, string dienthoai,  bool trangthai, string email)
        {
            Taikhoan tkc = _taiKhoanRepo.GetTaiKhoan().FirstOrDefault(x => x.IdTaikhoan == id);
            tkc.Hinhanh = hinhanh;
            tkc.Diachi = diachi;
            tkc.Dienthoai = dienthoai;
            tkc.TrangThai = trangthai;
            tkc.Email = email;  

            return _taiKhoanRepo.UpdateTaikhoan(tkc);
        }

        public List<Taikhoan> GetTKHByAll(string name)
        {
            return _taiKhoanRepo.GetTKBYAll(name).ToList();
        }


    }
}
