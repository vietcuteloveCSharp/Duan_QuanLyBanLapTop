using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("Nhaphangchitiet")]
public partial class Nhaphangchitiet
{
    [Key]
    [Column("id_nhct")]
    public int IdNhct { get; set; }

    [Column("imel")]
    [StringLength(15)]
    [Unicode(false)]
    public string Imel { get; set; } = null!;

    [Column("gianhap", TypeName = "decimal(18, 0)")]
    public decimal Gianhap { get; set; }

    [Column("id_nhaphang")]
    public int? IdNhaphang { get; set; }

    [ForeignKey("IdNhaphang")]
    [InverseProperty("Nhaphangchitiets")]
    public virtual Nhaphang? IdNhaphangNavigation { get; set; }

    [ForeignKey("Imel")]
    [InverseProperty("Nhaphangchitiets")]
    public virtual Laptopchitiet ImelNavigation { get; set; } = null!;
}
