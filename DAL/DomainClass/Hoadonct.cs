using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("hoadonct")]
public partial class Hoadonct
{
    [Key]
    [Column("id_hdct")]
    public int IdHdct { get; set; }

    [Column("imel")]
    [StringLength(15)]
    [Unicode(false)]
    public string Imel { get; set; } = null!;

    [Column("id_hoadon")]
    public int? IdHoadon { get; set; }

    [Column("gia", TypeName = "decimal(18, 0)")]
    public decimal Gia { get; set; }

    [ForeignKey("IdHoadon")]
    [InverseProperty("Hoadoncts")]
    public virtual Hoadon? IdHoadonNavigation { get; set; }

    [ForeignKey("Imel")]
    [InverseProperty("Hoadoncts")]
    public virtual Laptopchitiet ImelNavigation { get; set; } = null!;
}
