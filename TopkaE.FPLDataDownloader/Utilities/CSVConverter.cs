using ServiceStack.Text;
using System.Collections.Generic;
using TopkaE.FPLDataDownloader.Models.InputModels;

namespace TopkaE.FPLDataDownloader.Utilities
{
    public class CSVConverter
    {
        public string ConvertToCSV<T>(IEnumerable<T> objToConvert) where T : IFPLModel
        {
            return CsvSerializer.SerializeToString(objToConvert);
        }
        public string ConvertToCSV<T>(T objToConvert) where T : IFPLModel
        {
            return CsvSerializer.SerializeToString(objToConvert);
        }
    }
}
