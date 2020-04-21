using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace csvData
{
    public class LoadCSV
    {
        public static IList<T> LoadFile<T>(string _fileName)
        {
            IList<T> _records = new List<T>();

            using (var reader = new StreamReader("path\\to\\file.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>();
            }
            return _records;

        }
    }
}