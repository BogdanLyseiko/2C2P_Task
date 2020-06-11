using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _2c2pTask.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        ResultModel AddRange(IEnumerable<Transaction> transactions);
        IQueryable<Transaction> GetTransactions(Expression<Func<Transaction, bool>> predicate = null);
    }
}
