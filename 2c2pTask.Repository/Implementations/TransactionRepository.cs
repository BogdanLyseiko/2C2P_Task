using _2c2pTask.Models.Constants;
using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Models;
using _2c2pTask.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace _2c2pTask.Repository.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private DatabaseContext dbContext;
        private ILogger logger;

        public TransactionRepository(DatabaseContext dbContext, ILogger<TransactionRepository> logger)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }
        public ResultModel AddRange(IEnumerable<Transaction> transactions)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                dbContext.AddRange(transactions);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("TransactionRepository.AddRange", ex);
                resultModel.IsError = true;
                resultModel.Errors.Add(Constants.ADDING_DATA_ERROR);

                return resultModel;
            }

            return resultModel;
        }

        public IQueryable<Transaction> GetTransactions(Expression<Func<Transaction, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return dbContext.Transactions.Where(predicate).Include(x => x.Status);
            }

            return dbContext.Transactions;
        }
    }
}
