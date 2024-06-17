using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LocalDbContext : DbContext
    {
        private readonly string DbPath;
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Entity> Entities { get; set; }

        public LocalDbContext(string dbPath)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database={DbPath};ConnectRetryCount=5");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>()
                .HasMany(i => i.Addresses)
                .WithOne(i => i.Entity)
                .IsRequired(false);
            modelBuilder.Entity<Entity>()
                .HasMany(i => i.Dates)
                .WithOne(i => i.Entity)
                .IsRequired(false);
            modelBuilder.Entity<Entity>()
                .HasMany(i => i.Addresses)
                .WithOne(i => i.Entity)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
