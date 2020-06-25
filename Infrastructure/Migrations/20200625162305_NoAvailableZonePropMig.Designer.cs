﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(GAJDbContext))]
    [Migration("20200625162305_NoAvailableZonePropMig")]
    partial class NoAvailableZonePropMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.EntitiesCF.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genre");

                    b.Property<bool>("IsOnline");

                    b.Property<int>("PEGI");

                    b.Property<int>("Players");

                    b.Property<decimal?>("Price");

                    b.Property<DateTime?>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.EntitiesCF.GamePromotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountType");

                    b.Property<DateTime>("EndDate");

                    b.Property<Guid?>("GameId");

                    b.Property<Guid?>("PromotionId");

                    b.Property<DateTime>("StartDate");

                    b.Property<Guid?>("StudioId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("StudioId");

                    b.ToTable("GamePromotions");
                });

            modelBuilder.Entity("Domain.EntitiesCF.GameStudio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("GameId");

                    b.Property<Guid>("StudioId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("StudioId");

                    b.ToTable("GameStudio");
                });

            modelBuilder.Entity("Domain.EntitiesCF.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("Discount");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Domain.EntitiesCF.Studio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Established");

                    b.Property<string>("StudioName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("Domain.EntitiesCF.GamePromotion", b =>
                {
                    b.HasOne("Domain.EntitiesCF.Game", "Game")
                        .WithMany("GamePromotions")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.EntitiesCF.Promotion", "Promotion")
                        .WithMany("GamePromotion")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.EntitiesCF.Studio", "Studio")
                        .WithMany("GamePromotions")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.EntitiesCF.GameStudio", b =>
                {
                    b.HasOne("Domain.EntitiesCF.Game", "Game")
                        .WithMany("GameStudios")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.EntitiesCF.Studio", "Studio")
                        .WithMany("StudioGames")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
