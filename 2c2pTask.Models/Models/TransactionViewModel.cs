using _2c2pTask.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2c2pTask.Models.Models
{
    public class TransactionViewModel
    {
        public string ID { get; set; }
        public string Payment { get; set; }
        public char Status { get; set; }

        public static explicit operator TransactionViewModel(Transaction transaction)
        {
            return new TransactionViewModel
            {
                ID = transaction.ID,
                Payment = $"{transaction.Amount} {transaction.CurrencyCode}",
                Status = transaction.Status.Name[0]
            };
        }
    }
}
