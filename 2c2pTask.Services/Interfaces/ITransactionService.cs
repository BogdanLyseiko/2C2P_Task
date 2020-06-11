using Microsoft.AspNetCore.Http;

namespace _2c2pTask.Services.Interfaces
{
    public interface ITransactionService
    {
        public void AddTransactionsByFile(IFormFile transactionsFile);
    }
}
