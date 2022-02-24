using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace loanbook.Models
{
    public partial class kbookContext : DbContext
    {
        public kbookContext()
        {
        }

        public kbookContext(DbContextOptions<kbookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<KbookClient> KbookClients { get; set; } = null!;
        public virtual DbSet<StockMain> StockMains { get; set; } = null!;
        public virtual DbSet<Taxis> Taxes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PRAVEEN;Database=kbook;user id=sa;password=q1w2e3r4t5@#$;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customerID");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.CusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cus_name");

                entity.Property(e => e.Ordertotal).HasColumnName("ordertotal");

                entity.Property(e => e.Phoneno).HasColumnName("phoneno");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status_");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customer__client__38996AB5");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("itemID");

                entity.Property(e => e.GrpId).HasColumnName("grpID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("item_name");

                entity.HasOne(d => d.Grp)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.GrpId)
                    .HasConstraintName("FK__items__grpID__403A8C7D");
            });

            modelBuilder.Entity<KbookClient>(entity =>
            {
                entity.ToTable("kbook_client");

                entity.Property(e => e.KbookClientId)
                    .ValueGeneratedNever()
                    .HasColumnName("kbook_clientID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phoneno).HasColumnName("phoneno");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("status_");
            });

            modelBuilder.Entity<StockMain>(entity =>
            {
                entity.HasKey(e => e.GrpId)
                    .HasName("PK__stock_ma__1C889964702DE30C");

                entity.ToTable("stock_main");

                entity.Property(e => e.GrpId)
                    .ValueGeneratedNever()
                    .HasColumnName("grpID");

                entity.Property(e => e.Itemgroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("itemgroup");
            });

            modelBuilder.Entity<Taxis>(entity =>
            {
                entity.HasKey(e => e.TxnId)
                    .HasName("PK__taxes__6B9EFC0C6B7F7F93");

                entity.ToTable("taxes");

                entity.Property(e => e.TxnId)
                    .ValueGeneratedNever()
                    .HasColumnName("txnID");

                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Taxes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__taxes__customerI__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
