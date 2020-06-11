using _2c2pTask.Attributes;
using _2c2pTask.Models.Constants;
using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Enums;
using _2c2pTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

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
            var result = transactionService.AddTransactionsByFile(file);
            if (result.IsError)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [Route("GetByCurrency")]
        public ActionResult<IEnumerable<Transaction>> GetByCurrency(string currencyCode)
        {
            return Ok(transactionService.GetByCurrency(currencyCode));
        }

        [Route("GetByDateRange")]
        public ActionResult<IEnumerable<Transaction>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return Ok(transactionService.GetByDateRange(startDate, endDate));
        }

        [Route("GetByStatus")]
        public ActionResult<IEnumerable<Transaction>> GetByStatus(StatusesEnum status)
        {
            return Ok(transactionService.GetByStatus(status));
        }
    }
}