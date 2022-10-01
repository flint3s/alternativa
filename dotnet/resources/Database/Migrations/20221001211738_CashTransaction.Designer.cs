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
    [Migration("20221001211738_CashTransaction")]
    partial class CashTransaction
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

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int>("VipLevel")
                        .HasColumnType("integer");

                    b.HasKey("SocialClubId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.AccountEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

                    b.HasIndex("AccountSocialClubId");

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

                    b.Property<long?>("MainBankAccountId")
                        .HasColumnType("bigint");

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

            modelBuilder.Entity("Database.Models.ColShape", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Center")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Radius")
                        .HasColumnType("real");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ColShapes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ColShape");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Bank", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("BankId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BankId1")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("OwnerFinancesId")
                        .HasColumnType("uuid");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.Property<double>("Sum")
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

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("FromId")
                        .HasColumnType("bigint");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

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

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FromId")
                        .HasColumnType("bigint");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.Property<long?>("ToId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("CryptoTransactions");
                });

            modelBuilder.Entity("Database.Models.Economics.CryptoWallets.CryptoWallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid?>("CharacterFinancesId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CharacterFinancesId");

                    b.ToTable("CryptoWallets");
                });

            modelBuilder.Entity("Database.Models.Rooms.AbstractRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("EntranceId")
                        .HasColumnType("uuid");

                    b.Property<string>("Interior")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("EntranceId");

                    b.ToTable("Rooms");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractRoom");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.HasBaseType("Database.Models.AccountEvents.AccountEvent");

                    b.Property<decimal?>("AccountSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasIndex("AccountSocialClubId");

                    b.HasDiscriminator().HasValue("ConnectionEvent");
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

                    b.Property<decimal?>("GivenToSocialClubId")
                        .HasColumnType("numeric(20,0)");

                    b.HasIndex("GivenToSocialClubId");

                    b.HasDiscriminator().HasValue("TemporaryBan");
                });

            modelBuilder.Entity("Database.Models.Rooms.RoomColShape", b =>
                {
                    b.HasBaseType("Database.Models.ColShape");

                    b.Property<bool>("IsInternal")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("RoomColShape");
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.BetweenCharactersTransaction", b =>
                {
                    b.HasBaseType("Database.Models.Economics.Banks.Transactions.AbstractBankTransaction");

                    b.Property<long?>("ToId")
                        .HasColumnType("bigint");

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

            modelBuilder.Entity("Database.Models.Rooms.AbstractRealEstate", b =>
                {
                    b.HasBaseType("Database.Models.Rooms.AbstractRoom");

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("AbstractRealEstate");
                });

            modelBuilder.Entity("Database.Models.Rooms.Garage", b =>
                {
                    b.HasBaseType("Database.Models.Rooms.AbstractRealEstate");

                    b.Property<Guid?>("OwnerId1")
                        .HasColumnType("uuid");

                    b.HasIndex("OwnerId1");

                    b.HasDiscriminator().HasValue("Garage");
                });

            modelBuilder.Entity("Database.Models.Rooms.House", b =>
                {
                    b.HasBaseType("Database.Models.Rooms.AbstractRealEstate");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.HasIndex("OwnerId");

                    b.HasDiscriminator().HasValue("House");
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

            modelBuilder.Entity("Database.Models.Rooms.AbstractRoom", b =>
                {
                    b.HasOne("Database.Models.Rooms.RoomColShape", "Entrance")
                        .WithMany("Rooms")
                        .HasForeignKey("EntranceId");
                });

            modelBuilder.Entity("Database.Models.AccountEvents.ConnectionEvent", b =>
                {
                    b.HasOne("Database.Models.Account", null)
                        .WithMany("Connections")
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

            modelBuilder.Entity("Database.Models.Rooms.RoomColShape", b =>
                {
                    b.HasOne("Database.Models.Rooms.AbstractRoom", "Owner")
                        .WithOne("Exit")
                        .HasForeignKey("Database.Models.Rooms.RoomColShape", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Models.Economics.Banks.Transactions.BetweenCharactersTransaction", b =>
                {
                    b.HasOne("Database.Models.Economics.Banks.BankAccount", "To")
                        .WithMany()
                        .HasForeignKey("ToId");
                });

            modelBuilder.Entity("Database.Models.Rooms.Garage", b =>
                {
                    b.HasOne("Database.Models.Character", "Owner")
                        .WithMany("Garages")
                        .HasForeignKey("OwnerId1");
                });

            modelBuilder.Entity("Database.Models.Rooms.House", b =>
                {
                    b.HasOne("Database.Models.Character", "Owner")
                        .WithMany("Houses")
                        .HasForeignKey("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
