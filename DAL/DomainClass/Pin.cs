using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("Pin")]
public partial class Pin
{
    [Key]
    [Column("id_pin")]
    public int IdPin { get; set; }

    [Column("tenpin")]
    [StringLength(30)]
    public string Tenpin { get; set; } = null!;

    [Column("dungluong")]
    public int Dungluong { get; set; }

    [Column("loaipin")]
    [StringLength(20)]
    public string Loaipin { get; set; } = null!;

    [Column("thoigiansd")]
    public int Thoigiansd { get; set; }

    [Column("trangthai")]
    [StringLength(20)]
    public string Trangthai { get; set; } = null!;

    [InverseProperty("IdPinNavigation")]
    public virtual ICollection<Laptopchitiet> Laptopchitiets { get; set; } = new List<Laptopchitiet>();
}
