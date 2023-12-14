
namespace DAL.DomainClass
{
    public interface INhaphang
    {
        string Ghichu { get; set; }
        decimal Gianhap { get; set; }

        int? GetIdNhaphang();
        void SetIdNhaphang(int? value);

        int IdNhaphang { get; set; }
        Nhaphang? IdNhaphangNavigation { get; set; }
        int IdNhct { get; set; }
        int? IdTaikhoan { get; set; }
        Taikhoan? IdTaikhoanNavigation { get; set; }
        string Imel { get; set; }
        Laptopchitiet ImelNavigation { get; set; }
        DateTime Ngaynhap { get; set; }
        string Nhacungcap { get; set; }
        ICollection<Nhaphang> Nhaphangchitiets { get; set; }
        int Soluongnhhap { get; set; }
    }
}