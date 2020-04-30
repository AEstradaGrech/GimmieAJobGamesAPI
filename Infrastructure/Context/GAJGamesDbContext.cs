using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Context
{
    public partial class GAJGamesDbContext : DbContext
    {
        public GAJGamesDbContext()
        {
        }

        public GAJGamesDbContext(DbContextOptions<GAJGamesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAccountType> CustomerAccountType { get; set; }
        public virtual DbSet<GamePromotion> GamePromotion { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Promotions> Promotions { get; set; }
        public virtual DbSet<StudioGame> StudioGame { get; set; }
        public virtual DbSet<Studios> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=GAJGamesDb;uid=root;password=somepassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.Property(e => e.AccountDesc)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.HasGift)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustomerAccountTypeId)
                    .HasName("CustomerAccountTypeId");

                entity.Property(e => e.CountryZone).HasDefaultValueSql("'0'");

                entity.Property(e => e.CustomerAccountTypeId).HasDefaultValueSql("'0'");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                entity.HasOne(d => d.CustomerAccountType)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CustomerAccountTypeId)
                    .HasConstraintName("Customer_ibfk_1");
            });

            modelBuilder.Entity<CustomerAccountType>(entity =>
            {
                entity.HasIndex(e => e.AccountTypeId)
                    .HasName("AccountTypeId");

                entity.HasIndex(e => new { e.CustomerId, e.AccountTypeId })
                    .HasName("CustomerId_AccountId_IX")
                    .IsUnique();

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.CustomerAccountType)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerAccountType_ibfk_1");
            });

            modelBuilder.Entity<GamePromotion>(entity =>
            {
                entity.HasIndex(e => e.AccountTypeId)
                    .HasName("AccountTypeId");

                entity.HasIndex(e => e.StudioId)
                    .HasName("StudioId");

                entity.HasIndex(e => new { e.GameId, e.PromotionId })
                    .HasName("GameId_PromotionId_IX")
                    .IsUnique();

                entity.HasIndex(e => new { e.PromotionId, e.AccountTypeId })
                    .HasName("PromotionId_AccountTypeId_IX")
                    .IsUnique();

                entity.HasIndex(e => new { e.PromotionId, e.StudioId })
                    .HasName("PromotionId_StudioId_IX")
                    .IsUnique();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.GamePromotion)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("GamePromotion_ibfk_4");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GamePromotion)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("GamePromotion_ibfk_2");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.GamePromotion)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("GamePromotion_ibfk_3");

                entity.HasOne(d => d.Studio)
                    .WithMany(p => p.GamePromotion)
                    .HasForeignKey(d => d.StudioId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("GamePromotion_ibfk_1");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IsOnline)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.Property(e => e.Pegi)
                    .HasColumnName("PEGI")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.Platform).HasDefaultValueSql("'0'");

                entity.Property(e => e.Players).HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Promotions>(entity =>
            {
                entity.Property(e => e.IsValid)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.Property(e => e.PromoDesc).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<StudioGame>(entity =>
            {
                entity.HasIndex(e => e.StudioId)
                    .HasName("StudioId");

                entity.HasIndex(e => new { e.GameId, e.StudioId })
                    .HasName("GameId_StudioId_IX")
                    .IsUnique();

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.StudioGame)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("StudioGame_ibfk_2");

                entity.HasOne(d => d.Studio)
                    .WithMany(p => p.StudioGame)
                    .HasForeignKey(d => d.StudioId)
                    .HasConstraintName("StudioGame_ibfk_1");
            });

            modelBuilder.Entity<Studios>(entity =>
            {
                entity.Property(e => e.Established).HasColumnType("date");

                entity.Property(e => e.StudioName)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });
        }
    }
}
