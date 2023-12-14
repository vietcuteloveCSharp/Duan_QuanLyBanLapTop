using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("hang")]
public partial class Hang
{
    [Key]
    [Column("id_hang")]
    public int IdHang { get; set; }

    [Column("tenhang")]
    [StringLength(30)]
    public string Tenhang { get; set; } = null!;

    [Column("trangthai")]
    [StringLength(30)]
    public string? Trangthai { get; set; }

    [InverseProperty("IdhangNavigation")]
    public virtual ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
}
