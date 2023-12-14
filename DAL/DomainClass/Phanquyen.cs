using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("phanquyen")]
public partial class Phanquyen
{
    [Key]
    [Column("id_phanquyen")]
    public int IdPhanquyen { get; set; }

    [Column("tenquyen")]
    [StringLength(30)]
    public string Tenquyen { get; set; } = null!;

    [Column("quyen")]
    public int? Quyen { get; set; }

    [InverseProperty("IdPhanquyenNavigation")]
    public virtual ICollection<Taikhoan> Taikhoans { get; set; } = new List<Taikhoan>();
}
