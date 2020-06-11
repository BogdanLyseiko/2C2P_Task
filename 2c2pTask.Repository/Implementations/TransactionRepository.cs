using _2c2pTask.Models.Entities;
using _2c2pTask.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _2c2pTask.Repository.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private DatabaseContext dbContext;
        public TransactionRepository (DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddRange(IEnumerable<Transaction> transactions)
        {
            dbContext.AddRange(transactions);
            dbContext.SaveChanges();
        }

        public IQueryable<Transaction> GetTransactions(Expression<Func<Transaction, bool>> predicate = null)
        {
            if(predicate != null)
            {
                return dbContext.Transactions.Where(predicate);
            }

            return dbContext.Transactions;
        }
    }
}
