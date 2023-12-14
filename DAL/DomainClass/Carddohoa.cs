using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("Carddohoa")]
public partial class Carddohoa
{
    [Key]
    [Column("Id_carddohoa")]
    public int IdCarddohoa { get; set; }

    [Column("tencard")]
    [StringLength(30)]
    public string Tencard { get; set; } = null!;

    [Column("dungluong")]
    public int Dungluong { get; set; }

    [Column("trangthai")]
    [StringLength(20)]
    public string Trangthai { get; set; } = null!;

    [InverseProperty("IdCarddohoaNavigation")]
    public virtual ICollection<Laptopchitiet> Laptopchitiets { get; set; } = new List<Laptopchitiet>();
}
