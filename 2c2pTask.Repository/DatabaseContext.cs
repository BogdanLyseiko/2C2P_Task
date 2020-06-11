using _2c2pTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2c2pTask.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Transaction.Configure(modelBuilder);
            Status.Configure(modelBuilder);

            modelBuilder.Entity<Status>().HasData(
                new { ID = 1, Name = "Approved" },
                new { ID = 2, Name = "Rejected" },
                new { ID = 3, Name = "Done" });
        }
    }
}
