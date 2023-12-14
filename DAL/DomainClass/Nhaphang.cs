using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("nhaphang")]
public partial class Nhaphang
{
    [Key]
    [Column("id_nhaphang")]
    public int IdNhaphang { get; set; }

    [Column("ngaynhap", TypeName = "date")]
    public DateTime Ngaynhap { get; set; }

    [Column("nhacungcap")]
    [StringLength(50)]
    public string Nhacungcap { get; set; } = null!;

    [Column("ghichu")]
    [StringLength(50)]
    public string Ghichu { get; set; } = null!;

    [Column("soluongnhhap")]
    public int Soluongnhhap { get; set; }

    [Column("id_taikhoan")]
    public int? IdTaikhoan { get; set; }

    [ForeignKey("IdTaikhoan")]
    [InverseProperty("Nhaphangs")]
    public virtual Taikhoan? IdTaikhoanNavigation { get; set; }

    [InverseProperty("IdNhaphangNavigation")]
    public virtual ICollection<Nhaphangchitiet> Nhaphangchitiets { get; set; } = new List<Nhaphangchitiet>();
}
