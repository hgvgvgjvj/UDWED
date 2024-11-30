using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class PtwebContext : DbContext
{
    public PtwebContext()
    {
    }

    public PtwebContext(DbContextOptions<PtwebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TbAdmin> TbAdmins { get; set; }

    public virtual DbSet<TbBill> TbBills { get; set; }

    public virtual DbSet<TbBlog> TbBlogs { get; set; }

    public virtual DbSet<TbComment> TbComments { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

    public virtual DbSet<TbDetailedInvoice> TbDetailedInvoices { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductType> TbProductTypes { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source= LAPTOP-UILDMEI4; initial catalog=PTWEB; integrated security=True; \nTrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole).HasName("PK__Role__A1BA16C4743296AB");

            entity.ToTable("Role");

            entity.Property(e => e.Idrole)
                .ValueGeneratedNever()
                .HasColumnName("IDRole");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity.HasKey(e => e.AccountId);

            entity.ToTable("tb_Admin");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(500);
        });

        modelBuilder.Entity<TbBill>(entity =>
        {
            entity.HasKey(e => e.Idbill).HasName("PK__tb_Bill__23BDC1E6BC8AF852");

            entity.ToTable("tb_Bill");

            entity.Property(e => e.Idbill)
                .ValueGeneratedNever()
                .HasColumnName("IDBill");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.OrderCode).HasMaxLength(50);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UseId).HasColumnName("UseID");

            entity.HasOne(d => d.Use).WithMany(p => p.TbBills)
                .HasForeignKey(d => d.UseId)
                .HasConstraintName("FK__tb_Bill__OrderDa__4AB81AF0");
        });

        modelBuilder.Entity<TbBlog>(entity =>
        {
            entity.HasKey(e => e.Idblog).HasName("PK__tb_Blog__3CFB8BBEFEAD27AA");

            entity.ToTable("tb_Blog");

            entity.Property(e => e.Idblog)
                .ValueGeneratedNever()
                .HasColumnName("IDBlog");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ShortContent).HasMaxLength(2500);
            entity.Property(e => e.Title).HasMaxLength(500);
        });

        modelBuilder.Entity<TbComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__tb_Comme__C3B4DFCA136D4251");

            entity.ToTable("tb_Comment");

            entity.Property(e => e.CommentId).ValueGeneratedNever();
            entity.Property(e => e.CommentContent).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Idblog).HasColumnName("IDBlog");
            entity.Property(e => e.Idcommentator)
                .HasMaxLength(50)
                .HasColumnName("IDCommentator");

            entity.HasOne(d => d.IdblogNavigation).WithMany(p => p.TbComments)
                .HasForeignKey(d => d.Idblog)
                .HasConstraintName("FK__tb_Commen__IDBlo__45F365D3");
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__tb_Conta__5C66259B5E7B4382");

            entity.ToTable("tb_Contact");

            entity.Property(e => e.ContactId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<TbDetailedInvoice>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__tb_Detai__349DA5A66D934A77");

            entity.ToTable("tb_DetailedInvoice");

            entity.Property(e => e.AccountId).ValueGeneratedNever();
            entity.Property(e => e.Idbill).HasColumnName("IDBill");
            entity.Property(e => e.TotalPrice).HasColumnType("money");

            entity.HasOne(d => d.Product).WithMany(p => p.TbDetailedInvoices)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__tb_Detail__Produ__3D5E1FD2");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__tb_Produ__B40CC6CD626EB5D0");

            entity.ToTable("tb_Product");

            entity.Property(e => e.ProductId).ValueGeneratedNever();
            entity.Property(e => e.Idtype).HasColumnName("IDType");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(500);
            entity.Property(e => e.PromotionalPrice).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<TbProductType>(entity =>
        {
            entity.HasKey(e => e.Idtype);

            entity.ToTable("tb_ProductType");

            entity.Property(e => e.Idtype).HasColumnName("IDType");
            entity.Property(e => e.Images).HasMaxLength(500);
            entity.Property(e => e.Typename).HasMaxLength(500);
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UseId).HasName("PK__tb_User__64B2E0AA3D79CB99");

            entity.ToTable("tb_User");

            entity.Property(e => e.UseId)
                .ValueGeneratedNever()
                .HasColumnName("UseID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.Sdt).HasMaxLength(500);
            entity.Property(e => e.UseName).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
