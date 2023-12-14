using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("laptop")]
public partial class Laptop
{
    [Key]
    [Column("id_lt")]
    public int IdLt { get; set; }

    [Column("tenlaptop")]
    [StringLength(30)]
    public string Tenlaptop { get; set; } = null!;

    [Column("cannang")]
    public double Cannang { get; set; }

    [Column("mota")]
    [StringLength(100)]
    public string Mota { get; set; } = null!;

    [Column("trangthai")]
    [StringLength(20)]
    public string Trangthai { get; set; } = null!;

    [Column("idhang")]
    public int? Idhang { get; set; }

    [InverseProperty("IdlaptopNavigation")]
    public virtual ICollection<Hinhanh> Hinhanhs { get; set; } = new List<Hinhanh>();

    [ForeignKey("Idhang")]
    [InverseProperty("Laptops")]
    public virtual Hang? IdhangNavigation { get; set; }

    [InverseProperty("IdLaptopNavigation")]
    public virtual ICollection<Laptopchitiet> Laptopchitiets { get; set; } = new List<Laptopchitiet>();
}
