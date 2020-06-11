using _2c2pTask.Models.Constants;
using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Models;
using _2c2pTask.Repository.Interfaces;
using _2c2pTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2c2pTask.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository transactionRepository;
        private ILogger logger;

        public TransactionService(ITransactionRepository transactionRepository, ILogger<TransactionService> logger)
        {
            this.logger = logger;
            this.transactionRepository = transactionRepository;
        }
        public ResultModel AddTransactionsByFile(IFormFile transactionsFile)
        {
            var resultModel = new ResultModel();
            IEnumerable<Transaction> transactions;
            var fileConverter = FileConverterToTransactionsListFactory.GetFileCOnverterToTransactionsList(Path.GetExtension(transactionsFile.FileName));

            try
            {
                transactions = fileConverter.Convert(transactionsFile);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.PARSING_FILE_ERROR, ex);
                resultModel.IsError = true;
                resultModel.Errors.Add(Constants.PARSING_FILE_ERROR);
                return resultModel;
            }

            foreach (var item in transactions)
            {
                if (!item.IsValid())
                {
                    if (!resultModel.IsError)
                    {
                        resultModel.IsError = true;
                    }

                    resultModel.Errors.Add($"{Constants.TRANSACTION_IS_INVALID} Transaction id: {item.ID}");
                }
            }

            return resultModel.IsError ? resultModel : transactionRepository.AddRange(transactions);
        }
    }
}
