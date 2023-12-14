using System;
using System.Collections.Generic;
using DAL.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carddohoa> Carddohoas { get; set; }

    public virtual DbSet<Chip> Chips { get; set; }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<Hinhanh> Hinhanhs { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Hoadonct> Hoadoncts { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Laptop> Laptops { get; set; }

    public virtual DbSet<Laptopchitiet> Laptopchitiets { get; set; }

    public virtual DbSet<Nhaphang> Nhaphangs { get; set; }

    public virtual DbSet<Nhaphangchitiet> Nhaphangchitiets { get; set; }

    public virtual DbSet<Ocung> Ocungs { get; set; }

    public virtual DbSet<Phanquyen> Phanquyens { get; set; }

    public virtual DbSet<Pin> Pins { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-IRUEAU\\SQLEXPRESS; Initial Catalog=Laptop; Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carddohoa>(entity =>
        {
            entity.HasKey(e => e.IdCarddohoa).HasName("PK__Carddoho__37863A0CEAE5B9A4");
        });

        modelBuilder.Entity<Chip>(entity =>
        {
            entity.HasKey(e => e.IdChip).HasName("PK__chip__5EF20730C3358175");
        });

        modelBuilder.Entity<Hang>(entity =>
        {
            entity.HasKey(e => e.IdHang).HasName("PK__hang__B3CB97A5F25C2E2E");
        });

        modelBuilder.Entity<Hinhanh>(entity =>
        {
            entity.HasKey(e => e.IdHinhanh).HasName("PK__hinhanh__749680A94FA409CF");

            entity.HasOne(d => d.IdlaptopNavigation).WithMany(p => p.Hinhanhs).HasConstraintName("fk_hinhanh_laptop");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.IdHoadon).HasName("PK__hoadon__F9F513319267DAF0");

            entity.HasOne(d => d.IdKhachhangNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK_hoadon_khachhang");

            entity.HasOne(d => d.IdTaikhoanNavigation).WithMany(p => p.Hoadons).HasConstraintName("FK_hoadon_taikhoan");
        });

        modelBuilder.Entity<Hoadonct>(entity =>
        {
            entity.HasKey(e => e.IdHdct).HasName("PK__hoadonct__B3087471A48044AB");

            entity.HasOne(d => d.IdHoadonNavigation).WithMany(p => p.Hoadoncts).HasConstraintName("FK_hoadonct_hoadon");

            entity.HasOne(d => d.ImelNavigation).WithMany(p => p.Hoadoncts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hoadonct_ltct");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.IdKhachhang).HasName("PK__khachhan__63966DBD61813E87");
        });

        modelBuilder.Entity<Laptop>(entity =>
        {
            entity.HasKey(e => e.IdLt).HasName("PK__laptop__014883CDE00A11BD");

            entity.HasOne(d => d.IdhangNavigation).WithMany(p => p.Laptops).HasConstraintName("FK_laptop_hang");
        });

        modelBuilder.Entity<Laptopchitiet>(entity =>
        {
            entity.HasKey(e => e.Imel).HasName("PK__laptopch__9BF7BEBC8AAF3C97");

            entity.HasOne(d => d.IdCarddohoaNavigation).WithMany(p => p.Laptopchitiets).HasConstraintName("FK_laptopchitiet_carddohoa");

            entity.HasOne(d => d.IdChipNavigation).WithMany(p => p.Laptopchitiets).HasConstraintName("FK_laptopchitiet_chip");

            entity.HasOne(d => d.IdLaptopNavigation).WithMany(p => p.Laptopchitiets).HasConstraintName("FK_laptopchitiet_laptop");

            entity.HasOne(d => d.IdOcungNavigation).WithMany(p => p.Laptopchitiets).HasConstraintName("FK_laptopchitiet_ocung");

            entity.HasOne(d => d.IdPinNavigation).WithMany(p => p.Laptopchitiets).HasConstraintName("FK_laptopchitiet_Pin");

            entity.HasOne(d => d.IdRamNavigation).WithMany(p => p.Laptopchitiets).HasConstraintName("FK_laptopchitiet_ram");
        });

        modelBuilder.Entity<Nhaphang>(entity =>
        {
            entity.HasKey(e => e.IdNhaphang).HasName("PK__nhaphang__1777CD8B74DA02EB");

            entity.HasOne(d => d.IdTaikhoanNavigation).WithMany(p => p.Nhaphangs).HasConstraintName("FK_Nhaphang_taikhoan");
        });

        modelBuilder.Entity<Nhaphangchitiet>(entity =>
        {
            entity.HasKey(e => e.IdNhct).HasName("PK__Nhaphang__284ACE14E73857B8");

            entity.HasOne(d => d.IdNhaphangNavigation).WithMany(p => p.Nhaphangchitiets).HasConstraintName("FK_NHCT_nhaphang");

            entity.HasOne(d => d.ImelNavigation).WithMany(p => p.Nhaphangchitiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NHCT_ltct");
        });

        modelBuilder.Entity<Ocung>(entity =>
        {
            entity.HasKey(e => e.IdOcung).HasName("PK__ocung__35C1766F58C05C9E");
        });

        modelBuilder.Entity<Phanquyen>(entity =>
        {
            entity.HasKey(e => e.IdPhanquyen).HasName("PK__phanquye__45F86CE3360833E7");
        });

        modelBuilder.Entity<Pin>(entity =>
        {
            entity.HasKey(e => e.IdPin).HasName("PK__Pin__6FC862B88EE08D1D");
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.HasKey(e => e.IdRam).HasName("PK__Ram__2D95FA7652B381B6");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.IdTaikhoan).HasName("PK__taikhoan__353EB507EE26CE58");

            entity.HasOne(d => d.IdPhanquyenNavigation).WithMany(p => p.Taikhoans).HasConstraintName("FK_taikhoan_phanquyen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
