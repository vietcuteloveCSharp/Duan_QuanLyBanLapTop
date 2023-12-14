using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("hoadon")]
public partial class Hoadon
{
    [Key]
    [Column("id_hoadon")]
    public int IdHoadon { get; set; }

    [Column("chuthich")]
    [StringLength(100)]
    public string Chuthich { get; set; } = null!;

    [Column("ngaymua", TypeName = "datetime")]
    public DateTime Ngaymua { get; set; }

    [Column("tongtien", TypeName = "decimal(18, 0)")]
    public decimal Tongtien { get; set; }

    [Column("trangthai")]
    public bool Trangthai { get; set; }

    [Column("id_khachhang")]
    public int? IdKhachhang { get; set; }

    [Column("id_taikhoan")]
    public int? IdTaikhoan { get; set; }

    [InverseProperty("IdHoadonNavigation")]
    public virtual ICollection<Hoadonct> Hoadoncts { get; set; } = new List<Hoadonct>();

    [ForeignKey("IdKhachhang")]
    [InverseProperty("Hoadons")]
    public virtual Khachhang? IdKhachhangNavigation { get; set; }

    [ForeignKey("IdTaikhoan")]
    [InverseProperty("Hoadons")]
    public virtual Taikhoan? IdTaikhoanNavigation { get; set; }
}
