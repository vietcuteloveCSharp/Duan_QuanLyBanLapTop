using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("khachhang")]
public partial class Khachhang
{
    [Key]
    [Column("id_khachhang")]
    public int IdKhachhang { get; set; }

    [Column("tenkh")]
    [StringLength(50)]
    public string Tenkh { get; set; } = null!;

    [Column("diachi")]
    [StringLength(50)]
    public string Diachi { get; set; } = null!;

    [Column("dienthoai")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Dienthoai { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [InverseProperty("IdKhachhangNavigation")]
    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();
}
