using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SystemMonitoringAPI.Models;

namespace SystemMonitoringAPI.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Items> Items { get; set; }
        public DbSet<Borrowers> Borrowers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<DeletedTransactions> DeletedTransactions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>()
                .HasOne(i => i.Transactions)
                .WithMany()
                .IsRequired(false);

            modelBuilder.Entity<Transactions>()
               .Property(t => t.ItemName)
               .HasColumnName("ItemName");

            modelBuilder.Entity<Transactions>()
                .Property(t => t.BrwName)
                .HasColumnName("BrwName");

            modelBuilder.Entity<Transactions>()
                .Property(t => t.DprName)
                .HasColumnName("DprName");
        }
        #endregion
    }
}
