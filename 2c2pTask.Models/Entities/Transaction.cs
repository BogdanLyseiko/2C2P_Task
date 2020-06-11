using Microsoft.EntityFrameworkCore;
using System;

namespace _2c2pTask.Models.Entities
{
    public class Transaction
    {
        public string ID { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }

        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).HasMaxLength(50);
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.CurrencyCode).IsRequired().HasMaxLength(3);
                entity.Property(e => e.TransactionDate).IsRequired();
                entity.Property(e => e.StatusID).IsRequired();
                entity.HasOne(t => t.Status)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.StatusID);
            });
        }
    }
}
