using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Enums;
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
                new { ID = (int)StatusesEnum.Approved, Name = StatusesEnum.Approved.ToString() },
                new { ID = (int)StatusesEnum.Rejected, Name = StatusesEnum.Rejected.ToString() },
                new { ID = (int)StatusesEnum.Done, Name = StatusesEnum.Done.ToString() });
        }
    }
}
