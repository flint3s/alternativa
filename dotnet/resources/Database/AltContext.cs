﻿using System;
using System.Linq;
using Database.Models;
using Database.Models.AccountEvents;
using Database.Models.Bans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class AltContext : DbContext
    {
        public static object Locker { get; }
        
        public static AltContext Instance { get; }

        protected AltContext()
        {
        }
        
        private static readonly IConfigurationRoot Config;
        
        public DbSet<Account> Accounts { get; private set; }

        public DbSet<Character> Characters { get; private set; }

        public DbSet<AccountEvent> AccountEvents { get; private set; }

        public DbSet<AbstractBan> Bans { get; private set; }
        
        private static string ConnectionString => Config.GetConnectionString("AltDatabase");

        static AltContext()
        {
            Instance = new AltContext();
            Locker = new object();
            
            Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterConfigurations());
            
            modelBuilder.ApplyConfiguration<AccountEvent>(new EventConfigurations());
            modelBuilder.ApplyConfiguration<ConnectionEvent>(new EventConfigurations());
            
            modelBuilder.ApplyConfiguration<AbstractBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<TemporaryBan>(new BanConfigurations());
            modelBuilder.ApplyConfiguration<PermanentBan>(new BanConfigurations());
        }

        public override int SaveChanges()
        {
            IQueryable<EntityEntry<AbstractModel>> entries = ChangeTracker.Entries<AbstractModel>().AsQueryable();
            IQueryable<EntityEntry<AbstractModel>> models = entries.Where(entityEntry => entityEntry.Entity != null);
            IQueryable<EntityEntry<AbstractModel>> editedModels = models.Where(
                    e => e.State == EntityState.Added || e.State == EntityState.Modified
                );

            foreach (EntityEntry<AbstractModel> entityEntry in editedModels)
            {
                entityEntry.Entity.UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    entityEntry.Entity.CreatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }
    }
}