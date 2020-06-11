using System;
using System.Collections.Generic;
using System.Text;

namespace _2c2pTask.Models.Constants
{
    public class Constants
    {
        // maximum allowed file size is 5MB
        public const int MAX_FILE_SIZE = 5 * 1024 * 1024;
        public const string CSV_FORMAT = ".csv";
        public const string XML_FORMAT = ".xml";
        public const string CSV_DATE_FORMAT = "dd/MM/yyyy hh:mm:ss";
        public const string PARSING_FILE_ERROR = "Parsing file error";
        public const string ADDING_DATA_ERROR = "Error occured while saving data to database";
        public const string TRANSACTION_IS_INVALID = "Transaction is invalid.";
    }
}
