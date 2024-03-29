﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    [DbContext(typeof(AltContext))]
    [Migration("20221016020939_RealtyImprovements")]
    partial class RealtyImprovements
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AdminLevel")
                        .HasColumnType("integer");

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

                    b.Property<decimal>("SocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int>("VipLevel")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.AccountEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HWID")
                        .HasColumnType("text");

                    b.Property<string>("Ip")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("AccountEvents");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AccountEvent");
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

                    b.Property<Guid?>("GivenById")
                        .HasColumnType("uuid");

                    b.Property<int>("Reason")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GivenById");

                    b.ToTable("Bans");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractBan");
                });

            modelBuilder.Entity("Database.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("InGameTime")
                        .HasColumnType("interval");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<long>("StaticId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<TimeSpan>("TimeToReborn")
                        .HasColumnType("interval");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Database.Models.CharacterAppearance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<float>>("FaceFeatures")
                        .HasColumnType("real[]");

                    b.Property<byte>("FatherId")
                        .HasColumnType("smallint");

                    b.Property<byte>("MotherId")
                        .HasColumnType("smallint");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<float>("Similarity")
                        .HasColumnType("real");

                    b.Property<float>("SkinSimilarity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("CharacterAppearance");
                });

            modelBuilder.Entity("Database.Models.CharacterFinances", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Cash")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("MainBankAccountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MainBankAccountId");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("CharacterFinances");
                });

            modelBuilder.Entity("Database.Models.CharacterSpawnData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Armor")
                        .HasColumnType("integer");

                    b.Property<long>("Dimension")
                        .HasColumnType("bigint");

                    b.Property<float>("Heading")
                        .HasColumnType("real");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("CharacterSpawnData");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Money")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("BankId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BankId1")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("OwnerFinancesId")
                        .HasColumnType("uuid");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("BankId1");

                    b.HasIndex("OwnerFinancesId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.AbstractBankTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("FromId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.ToTable("BankTransactions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractBankTransaction");
                });

            modelBuilder.Entity("Database.Models.Economics.Cash.CashTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("FromId")
                        .HasColumnType("uuid");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("ToId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("CashTransactions");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("FromId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ToId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("CryptoTransactions");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("CharacterFinancesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CharacterFinancesId");

                    b.ToTable("CryptoWallets");
                });

            modelBuilder.Entity("Database.Models.Realty.Interior", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Entrance")
                        .HasColumnType("text");

                    b.Property<string>("Exit")
                        .HasColumnType("text");

                    b.Property<string>("IplName")
                        .HasColumnType("text");

                    b.Property<bool>("IsWindowed")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Interior");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedDate = new DateTime(2022, 10, 16, 5, 9, 38, 577, DateTimeKind.Local).AddTicks(126),
                            Entrance = "{\"x\":1973.35,\"y\":3816.34,\"z\":33.43}",
                            Exit = "{\"x\":1973.35,\"y\":3816.34,\"z\":33.43}",
                            IplName = "TrevorsTrailerTidy",
                            IsWindowed = true,
                            Name = "Автодом Тревора",
                            UpdatedDate = new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(639)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedDate = new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3045),
                            Entrance = "{\"x\":266.3,\"y\":-1007.4,\"z\":-101.0}",
                            Exit = "{\"x\":266.3,\"y\":-1007.4,\"z\":-101.0}",
                            IplName = "",
                            IsWindowed = false,
                            Name = "Low End Apartment",
                            UpdatedDate = new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3053)
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            CreatedDate = new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3121),
                            Entrance = "{\"x\":347.26,\"y\":-999.29,\"z\":-99.2}",
                            Exit = "{\"x\":347.26,\"y\":-999.29,\"z\":-99.2}",
                            IplName = "",
                            IsWindowed = false,
                            Name = "Medium End Apartment	",
                            UpdatedDate = new DateTime(2022, 10, 16, 5, 9, 38, 578, DateTimeKind.Local).AddTicks(3122)
                        });
                });

            modelBuilder.Entity("Database.Models.Realty.Realty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("EntranceId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PrototypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("EntranceId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PrototypeId");

                    b.ToTable("Realty");
                });

            modelBuilder.Entity("Database.Models.Realty.RealtyEntrance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Entrances");
                });

            modelBuilder.Entity("Database.Models.Realty.RealtyPrototype", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("GovernmentPrice")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("InteriorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<byte>("ParkingPlaces")
                        .HasColumnType("smallint");

                    b.Property<byte>("PriceSegment")
                        .HasColumnType("smallint");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("InteriorId");

                    b.ToTable("RealtyPrototype");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0001-000000000001"),
                            CreatedDate = new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GovernmentPrice = 100000000L,
                            InteriorId = new Guid("00000000-0000-0000-0000-000000000001"),
                            Name = "Дом эконом-класса",
                            ParkingPlaces = (byte)2,
                            PriceSegment = (byte)1,
                            Type = (byte)0,
                            UpdatedDate = new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.HasBaseType("Database.Models.AccountEvents.AccountEvent");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasIndex("AccountId");

                    b.HasDiscriminator().HasValue("ConnectionEvent");
                });

            modelBuilder.Entity("Database.Models.Bans.PermanentBan", b =>
                {
                    b.HasBaseType("Database.Models.Bans.AbstractBan");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<string>("HWID")
                        .HasColumnType("text");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("PermanentBan");
                });

            modelBuilder.Entity("Database.Models.Bans.TemporaryBan", b =>
                {
                    b.HasBaseType("Database.Models.Bans.AbstractBan");

                    b.Property<Guid?>("GivenToId")
                        .HasColumnType("uuid");

                    b.HasIndex("GivenToId");

                    b.HasDiscriminator().HasValue("TemporaryBan");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.BetweenCharactersTransaction", b =>
                {
                    b.HasBaseType("Database.Models.Economics.Banks.Transactions.AbstractBankTransaction");

                    b.Property<Guid?>("ToId")
                        .HasColumnType("uuid");

                    b.HasIndex("ToId");

                    b.HasDiscriminator().HasValue("BetweenCharactersTransaction");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.DutyTransaction", b =>
                {
                    b.HasBaseType("Database.Models.Economics.Banks.Transactions.AbstractBankTransaction");

                    b.HasDiscriminator().HasValue("DutyTransaction");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.PurchaseTransaction", b =>
                {
                    b.HasBaseType("Database.Models.Economics.Banks.Transactions.AbstractBankTransaction");

                    b.HasDiscriminator().HasValue("PurchaseTransaction");
                });

            modelBuilder.Entity("Database.Models.Bans.AbstractBan", b =>
                {
                    b.HasOne("Database.Models.Account", "GivenBy")
                        .WithMany()
                        .HasForeignKey("GivenById");
                });

            modelBuilder.Entity("Database.Models.Character", b =>
                {
                    b.HasOne("Database.Models.Account", "Account")
                        .WithMany("Characters")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.CharacterAppearance", b =>
                {
                    b.HasOne("Database.Models.Character", "Owner")
                        .WithOne("Appearance")
                        .HasForeignKey("Database.Models.CharacterAppearance", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.CharacterFinances", b =>
                {
                    b.HasOne("Database.Models.Economics.Banks.BankAccount", "MainBankAccount")
                        .WithMany()
                        .HasForeignKey("MainBankAccountId");

                    b.HasOne("Database.Models.Character", "Owner")
                        .WithOne("Finances")
                        .HasForeignKey("Database.Models.CharacterFinances", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.CharacterSpawnData", b =>
                {
                    b.HasOne("Database.Models.Character", "Owner")
                        .WithOne("SpawnData")
                        .HasForeignKey("Database.Models.CharacterSpawnData", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.BankAccount", b =>
                {
                    b.HasOne("Database.Models.Economics.Banks.Bank", null)
                        .WithMany("Accounts")
                        .HasForeignKey("BankId");

                    b.HasOne("Database.Models.Economics.Banks.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId1");

                    b.HasOne("Database.Models.CharacterFinances", "OwnerFinances")
                        .WithMany("BankAccounts")
                        .HasForeignKey("OwnerFinancesId");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.AbstractBankTransaction", b =>
                {
                    b.HasOne("Database.Models.Economics.Banks.BankAccount", "From")
                        .WithMany("Transactions")
                        .HasForeignKey("FromId");
                });

            modelBuilder.Entity("Database.Models.Economics.Cash.CashTransaction", b =>
                {
                    b.HasOne("Database.Models.Character", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("Database.Models.Character", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoTransaction", b =>
                {
                    b.HasOne("Database.Models.Economics.CryptoWallets.CryptoWallet", "From")
                        .WithMany("Transactions")
                        .HasForeignKey("FromId");

                    b.HasOne("Database.Models.Economics.CryptoWallets.CryptoWallet", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoWallet", b =>
                {
                    b.HasOne("Database.Models.CharacterFinances", null)
                        .WithMany("CryptoWallets")
                        .HasForeignKey("CharacterFinancesId");
                });

            modelBuilder.Entity("Database.Models.Realty.Realty", b =>
                {
                    b.HasOne("Database.Models.Realty.RealtyEntrance", "Entrance")
                        .WithMany("Realties")
                        .HasForeignKey("EntranceId");

                    b.HasOne("Database.Models.Character", "Owner")
                        .WithMany("Realties")
                        .HasForeignKey("OwnerId");

                    b.HasOne("Database.Models.Realty.RealtyPrototype", "Prototype")
                        .WithMany()
                        .HasForeignKey("PrototypeId");
                });

            modelBuilder.Entity("Database.Models.Realty.RealtyPrototype", b =>
                {
                    b.HasOne("Database.Models.Realty.Interior", "Interior")
                        .WithMany()
                        .HasForeignKey("InteriorId");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.HasOne("Database.Models.Account", null)
                        .WithMany("Connections")
                        .HasForeignKey("AccountId")
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
                        .HasForeignKey("GivenToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.BetweenCharactersTransaction", b =>
                {
                    b.HasOne("Database.Models.Economics.Banks.BankAccount", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });
#pragma warning restore 612, 618
        }
    }
}
