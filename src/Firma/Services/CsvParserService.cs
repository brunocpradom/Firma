using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Firma.Services
{
    public class CsvParserService
    {
        public async Task<string> ProcessaCsvCnaes()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp");
            var files = Directory.GetFiles(destinationDirectory);
            foreach(var file in files)
            {
                Console.WriteLine(file);
                var reader = new StreamReader(file)
            }
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            
        }
    }
}