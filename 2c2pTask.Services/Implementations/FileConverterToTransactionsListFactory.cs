using _2c2pTask.Models.Constants;
using _2c2pTask.Services.Interfaces;

namespace _2c2pTask.Services.Implementations
{
    public class FileConverterToTransactionsListFactory
    {
        public static IFileConverterToTransactionsList GetFileCOnverterToTransactionsList(string fileExtension)
        {
            switch(fileExtension) 
            {
                case Constants.CSV_FORMAT: return new CsvFileConverterToTransactionsList();
                case Constants.XML_FORMAT: return new XmlFileConverterToTransactionsList();
            }

            return null;
        }
    }
}
