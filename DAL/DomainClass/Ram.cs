using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("Ram")]
public partial class Ram
{
    [Key]
    [Column("Id_ram")]
    public int IdRam { get; set; }

    [Column("tenram")]
    [StringLength(20)]
    public string Tenram { get; set; } = null!;

    [Column("bus")]
    public int Bus { get; set; }

    [Column("trangthai")]
    [StringLength(20)]
    public string Trangthai { get; set; } = null!;

    [InverseProperty("IdRamNavigation")]
    public virtual ICollection<Laptopchitiet> Laptopchitiets { get; set; } = new List<Laptopchitiet>();
}
