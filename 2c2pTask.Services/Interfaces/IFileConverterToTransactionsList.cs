using _2c2pTask.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace _2c2pTask.Services.Interfaces
{
    public interface IFileConverterToTransactionsList
    {
        IEnumerable<Transaction> Convert(IFormFile file);
    }
}
