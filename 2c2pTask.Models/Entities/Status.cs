using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _2c2pTask.Models.Entities
{
    public class Status
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Transaction> Transactions { get; set; }

        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(s => s.Transactions)
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusID);
            });
        }
    }
}
