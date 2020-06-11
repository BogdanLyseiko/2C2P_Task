using _2c2pTask.Attributes;
using _2c2pTask.Models.Constants;
using _2c2pTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2c2pTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionService transactionService;

        public TransactionController(ITransactionService fileConverterToTransactionsList)
        {
            this.transactionService = fileConverterToTransactionsList;
        }

        [HttpPost]
        [Route("BulkUpload")]
        public ActionResult<string> BulkUpload([MaxFileSize(Constants.MAX_FILE_SIZE)] 
                                               [AllowedExtensionsAttribute(new string[] { Constants.CSV_FORMAT, Constants.XML_FORMAT })]
                                                IFormFile file)
        {
            transactionService.AddTransactionsByFile(file);
            return "test response";
        }
    }
}