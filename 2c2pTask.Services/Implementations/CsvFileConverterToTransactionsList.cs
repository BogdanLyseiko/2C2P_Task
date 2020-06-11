using _2c2pTask.Models.Constants;
using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Enums;
using _2c2pTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2c2pTask.Services.Implementations
{
    public class CsvFileConverterToTransactionsList : IFileConverterToTransactionsList
    {
        public IEnumerable<Transaction> Convert(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var csvLines = Encoding.UTF8.GetString(ms.ToArray())?.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                if (csvLines.Length > 0)
                {
                    return csvLines.Select(x => cSVLineToTransaction(x));
                }
            }

            return null;
        }

        private Transaction cSVLineToTransaction(string csvLine)
        {
            string[] values = csvLine?.Split(',');
            string dbStatusString = cSVStatusToDbStatus(values[4]);
            var dbStatusID = (int)Enum.Parse(typeof(StatusesEnum), dbStatusString);

            Transaction transaction = new Transaction
            {
                ID = values[0],
                Amount = decimal.Parse(values[1]),
                CurrencyCode = values[2],
                TransactionDate = DateTime.ParseExact(values[3], Constants.CSV_DATE_FORMAT, null),
                StatusID = dbStatusID
            };

            return transaction;
        }

        private string cSVStatusToDbStatus(string cSVStatus)
        {
            switch (cSVStatus)
            {
                case "Approved": return cSVStatus;
                case "Failed": return StatusesEnum.Rejected.ToString();
                case "Finished": return StatusesEnum.Done.ToString();
                default: return StatusesEnum.Approved.ToString();
            }
        }
    }
}
