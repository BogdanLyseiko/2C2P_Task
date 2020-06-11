using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Enums;
using _2c2pTask.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _2c2pTask.Services.Interfaces
{
    public interface ITransactionService
    {
        public ResultModel AddTransactionsByFile(IFormFile transactionsFile);
        public IEnumerable<TransactionViewModel> GetByCurrency(string currencyCode);
        public IEnumerable<TransactionViewModel> GetByDateRange(DateTime startDate, DateTime endDate);
        public IEnumerable<TransactionViewModel> GetByStatus(StatusesEnum status);
    }
}
