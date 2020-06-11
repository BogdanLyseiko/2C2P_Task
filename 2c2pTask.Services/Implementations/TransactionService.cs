using _2c2pTask.Repository.Interfaces;
using _2c2pTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace _2c2pTask.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public void AddTransactionsByFile(IFormFile transactionsFile)
        {
            var fileConverter = FileConverterToTransactionsListFactory.GetFileCOnverterToTransactionsList(Path.GetExtension(transactionsFile.FileName));
            var transactions = fileConverter.Convert(transactionsFile);
            transactionRepository.AddRange(transactions);
        }
    }
}
