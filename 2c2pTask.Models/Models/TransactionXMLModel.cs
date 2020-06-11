using System;
using System.Xml.Serialization;

namespace _2c2pTask.Models.Models
{
    public class TransactionXMLModel
    {
        [XmlAttribute("id")]
        public string ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public PaymentDetailsXMLModel PaymentDetails { get; set; }
        public string Status { get; set; }
    }
}