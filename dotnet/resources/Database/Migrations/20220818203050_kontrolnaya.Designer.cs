﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    [DbContext(typeof(AltContext))]
    [Migration("20220818203050_kontrolnaya")]
    partial class kontrolnaya
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Database.Models.Account", b =>
                {
                    b.Property<decimal>("SocialClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<Guid?>("ActiveCharacterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("LastHwid")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("SocialClubId");

                    b.HasIndex("ActiveCharacterId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal?>("AccountSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("HWID")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountSocialClubId");

                    b.ToTable("ConnectionEvents");
                });

            modelBuilder.Entity("Database.Models.Bans.AbstractBan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("GivenBySocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Reason")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GivenBySocialClubId");

                    b.ToTable("Bans");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractBan");
                });

            modelBuilder.Entity("Database.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("AccountSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Cash")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountSocialClubId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Database.Models.Bans.PermanentBan", b =>
                {
                    b.HasBaseType("Database.Models.Bans.AbstractBan");

                    b.Property<decimal>("AccountId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("HWID")
                        .HasColumnType("text");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("PermanentBan");
                });

            modelBuilder.Entity("Database.Models.Bans.TemporaryBan", b =>
                {
                    b.HasBaseType("Database.Models.Bans.AbstractBan");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("interval");

                    b.Property<decimal?>("GivenToSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.HasIndex("GivenToSocialClubId");

                    b.HasDiscriminator().HasValue("TemporaryBan");
                });

            modelBuilder.Entity("Database.Models.Account", b =>
                {
                    b.HasOne("Database.Models.Character", "ActiveCharacter")
                        .WithMany()
                        .HasForeignKey("ActiveCharacterId");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.HasOne("Database.Models.Account", null)
                        .WithMany("Connections")
                        .HasForeignKey("AccountSocialClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Bans.AbstractBan", b =>
                {
                    b.HasOne("Database.Models.Account", "GivenBy")
                        .WithMany()
                        .HasForeignKey("GivenBySocialClubId");
                });

            modelBuilder.Entity("Database.Models.Character", b =>
                {
                    b.HasOne("Database.Models.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("AccountSocialClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Bans.PermanentBan", b =>
                {
                    b.HasOne("Database.Models.Account", "GivenTo")
                        .WithOne("PermanentBan")
                        .HasForeignKey("Database.Models.Bans.PermanentBan", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Bans.TemporaryBan", b =>
                {
                    b.HasOne("Database.Models.Account", "GivenTo")
                        .WithMany("TemporaryBans")
                        .HasForeignKey("GivenToSocialClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
