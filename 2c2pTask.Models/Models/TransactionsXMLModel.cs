using System.Collections.Generic;
using System.Xml.Serialization;

namespace _2c2pTask.Models.Models
{
    [XmlRoot("Transactions")]
    public class TransactionsXMLModel
    {
        [XmlElement("Transaction")]
        public List<TransactionXMLModel> Transactions { get; set; }
    }
}
