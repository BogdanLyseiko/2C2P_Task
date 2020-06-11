using _2c2pTask.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _2c2pTask.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        void AddRange(IEnumerable<Transaction> transactions);
        IQueryable<Transaction> GetTransactions(Expression<Func<Transaction, bool>> predicate = null);
    }
}
