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
        public DbSet<Department> Departments { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region 
        //for key less models
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Transactions>().OwnsOne(a => a.Borrowers); 
        //base.OnModelCreating(modelBuilder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //  optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SystemDB;Trusted_Connection=True;TrustServerCertificate=True");
        //base.OnConfiguring(optionsBuilder);
        //}
        #endregion
    }
}
