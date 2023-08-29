﻿#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineStore.Entities.Entities;
using Type = OnlineStore.Entities.Entities.Type;

namespace OnlineStore.DataAccess.EntityFramework.Context
{
    public partial class StoreDataBaseContext : DbContext
    {
        public StoreDataBaseContext()
        {
        }

        public StoreDataBaseContext(DbContextOptions<StoreDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Measure> Measure { get; set; }
        public virtual DbSet<OrderedItems> OrderedItems { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductMeasure> ProductMeasure { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserString> UserString { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StoreDataBase;Integrated Security=True; Encrypt=False ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Category__Gender__440B1D61");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Iso)
                    .HasMaxLength(50)
                    .HasColumnName("ISO");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Goods>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Goods__ProductId__6383C8BA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Goods__UserId__628FA481");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Picture).IsRequired();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Image__ProductId__571DF1D5");
            });

            modelBuilder.Entity<Measure>(entity =>
            {
                entity.Property(e => e.MeasureValue)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Measure)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Measure__TypeId__3F466844");
            });

            modelBuilder.Entity<OrderedItems>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderedI__08D097A3E9AE03FE");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderedIt__Order__6A30C649");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderedItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderedIt__Produ__693CA210");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandId__4E88ABD4");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__4F7CD00D");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__Product__ColorId__5070F446");
            });

            modelBuilder.Entity<ProductMeasure>(entity =>
            {
                entity.HasOne(d => d.Measure)
                    .WithMany(p => p.ProductMeasure)
                    .HasForeignKey(d => d.MeasureId)
                    .HasConstraintName("FK__ProductMe__Measu__5441852A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMeasure)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductMe__Produ__534D60F1");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Receipt__UserId__66603565");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProductId, e.MeasureId })
                    .HasName("PK__Shopping__5D4456F0C894054C");

                entity.HasOne(d => d.Measure)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.MeasureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__Measu__5BE2A6F2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ShoppingC__Produ__5AEE82B9");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ShoppingC__UserI__59FA5E80");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "Unique_Email")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "Unique_UserName")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__User__CountryId__4AB81AF0");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__4BAC3F29");
            });

            modelBuilder.Entity<UserString>(entity =>
            {
                entity.Property(e => e.RandomString).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserString)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserStrin__UserI__6D0D32F4");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProductId })
                    .HasName("PK__WhisList__DCC800202F420787");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WishList)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__WhisList__Produc__5FB337D6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WishList)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WhisList__UserId__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}