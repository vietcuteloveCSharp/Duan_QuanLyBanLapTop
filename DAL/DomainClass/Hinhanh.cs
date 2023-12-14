using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("hinhanh")]
public partial class Hinhanh
{
    [Key]
    [Column("Id_hinhanh")]
    public int IdHinhanh { get; set; }

    [Column("Src")]
    public string Src { get; set; } = null!;

    [Column("nguoitao")]
    public string Nguoitao { get; set; } = null!;

    [Column("ngaytao", TypeName = "date")]
    public DateTime Ngaytao { get; set; }

    [Column("idlaptop")]
    public int? Idlaptop { get; set; }

    [ForeignKey("Idlaptop")]
    [InverseProperty("Hinhanhs")]
    public virtual Laptop? IdlaptopNavigation { get; set; }
}
