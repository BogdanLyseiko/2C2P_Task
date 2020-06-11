using _2c2pTask.Models.Entities;
using _2c2pTask.Models.Enums;
using _2c2pTask.Models.Models;
using _2c2pTask.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace _2c2pTask.Services.Implementations
{
    public class XmlFileConverterToTransactionsList : IFileConverterToTransactionsList
    {
        public IEnumerable<Transaction> Convert(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var serializer = new XmlSerializer(typeof(TransactionsXMLModel));
                using (MemoryStream xmlMemoryStream = new MemoryStream(ms.ToArray()))
                {
                    var deserializedTransactions = (TransactionsXMLModel)serializer.Deserialize(xmlMemoryStream);

                    return deserializedTransactions.Transactions.Select(x => convertTransactionXMLModelToTransactionEntity(x));
                }
            }
        }

        private Transaction convertTransactionXMLModelToTransactionEntity(TransactionXMLModel transactionXMLModel)
        {
            return new Transaction
            {
                ID = transactionXMLModel.ID,
                Amount = transactionXMLModel.PaymentDetails.Amount,
                StatusID = (int)Enum.Parse(typeof(StatusesEnum), transactionXMLModel.Status),
                CurrencyCode = transactionXMLModel.PaymentDetails.CurrencyCode,
                TransactionDate = transactionXMLModel.TransactionDate
            };
        }
    }
}