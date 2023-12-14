using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("ocung")]
public partial class Ocung
{
    [Key]
    [Column("Id_ocung")]
    public int IdOcung { get; set; }

    [Column("dungluong")]
    public int Dungluong { get; set; }

    [Column("tenocung")]
    [StringLength(30)]
    public string Tenocung { get; set; } = null!;

    [Column("loai")]
    [StringLength(20)]
    public string Loai { get; set; } = null!;

    [InverseProperty("IdOcungNavigation")]
    public virtual ICollection<Laptopchitiet> Laptopchitiets { get; set; } = new List<Laptopchitiet>();
}
