using _2c2pTask.Models.Models;
using Microsoft.AspNetCore.Http;

namespace _2c2pTask.Services.Interfaces
{
    public interface ITransactionService
    {
        public ResultModel AddTransactionsByFile(IFormFile transactionsFile);
    }
}
