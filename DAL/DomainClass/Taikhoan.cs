using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("taikhoan")]
public partial class Taikhoan
{
    [Key]
    [Column("id_taikhoan")]
    public int IdTaikhoan { get; set; }

    [Column("username")]
    [StringLength(30)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(30)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("hoten")]
    [StringLength(50)]
    public string Hoten { get; set; } = null!;

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

    [Column("hinhanh")]
    public string Hinhanh { get; set; } = null!;

    [Column("ngaysinh", TypeName = "datetime")]
    public DateTime Ngaysinh { get; set; }

    [Column("id_phanquyen")]
    public int? IdPhanquyen { get; set; }

    public bool? TrangThai { get; set; }

    [InverseProperty("IdTaikhoanNavigation")]
    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    [ForeignKey("IdPhanquyen")]
    [InverseProperty("Taikhoans")]
    public virtual Phanquyen? IdPhanquyenNavigation { get; set; }

    [InverseProperty("IdTaikhoanNavigation")]
    public virtual ICollection<Nhaphang> Nhaphangs { get; set; } = new List<Nhaphang>();
}
