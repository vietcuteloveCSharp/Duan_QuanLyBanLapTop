using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("chip")]
public partial class Chip
{
    [Key]
    [Column("Id_chip")]
    public int IdChip { get; set; }

    [Column("tenchip")]
    [StringLength(30)]
    public string Tenchip { get; set; } = null!;

    [Column("trangthai")]
    [StringLength(20)]
    public string Trangthai { get; set; } = null!;

    [InverseProperty("IdChipNavigation")]
    public virtual ICollection<Laptopchitiet> Laptopchitiets { get; set; } = new List<Laptopchitiet>();
}
