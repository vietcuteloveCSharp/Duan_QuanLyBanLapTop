using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DAL.DomainClass;

[Table("laptopchitiet")]
public partial class Laptopchitiet
{
    [Key]
    [Column("imel")]
    [StringLength(15)]
    [Unicode(false)]
    public string Imel { get; set; } = null!;

    [Column("Id_pin")]
    public int? IdPin { get; set; }

    [Column("Id_chip")]
    public int? IdChip { get; set; }

    [Column("id_hang")]
    public int? IdHang { get; set; }

    [Column("Id_ram")]
    public int? IdRam { get; set; }

    [Column("Id_carddohoa")]
    public int? IdCarddohoa { get; set; }

    [Column("Id_ocung")]
    public int? IdOcung { get; set; }

    [Column("Id_laptop")]
    public int? IdLaptop { get; set; }

    public bool TrangThai { get; set; }

    [Column("gianhap", TypeName = "decimal(18, 0)")]
    public decimal? Gianhap { get; set; }

    [InverseProperty("ImelNavigation")]
    public virtual ICollection<Hoadonct> Hoadoncts { get; set; } = new List<Hoadonct>();

    [ForeignKey("IdCarddohoa")]
    [InverseProperty("Laptopchitiets")]
    public virtual Carddohoa? IdCarddohoaNavigation { get; set; }

    [ForeignKey("IdChip")]
    [InverseProperty("Laptopchitiets")]
    public virtual Chip? IdChipNavigation { get; set; }

    [ForeignKey("IdLaptop")]
    [InverseProperty("Laptopchitiets")]
    public virtual Laptop? IdLaptopNavigation { get; set; }

    [ForeignKey("IdOcung")]
    [InverseProperty("Laptopchitiets")]
    public virtual Ocung? IdOcungNavigation { get; set; }

    [ForeignKey("IdPin")]
    [InverseProperty("Laptopchitiets")]
    public virtual Pin? IdPinNavigation { get; set; }

    [ForeignKey("IdRam")]
    [InverseProperty("Laptopchitiets")]
    public virtual Ram? IdRamNavigation { get; set; }

    [InverseProperty("ImelNavigation")]
    public virtual ICollection<Nhaphangchitiet> Nhaphangchitiets { get; set; } = new List<Nhaphangchitiet>();
}
