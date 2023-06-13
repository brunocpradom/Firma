using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Firma.Dtos.Csv;
using System.Text;

namespace Firma.Services
{
    public class CsvParserService : ICsvParserService
    {
        public string ProcessaCsvCnaes()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp");
            var files = Directory.GetFiles(destinationDirectory);
            foreach(var file in files)
            {
                Console.WriteLine(file);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = ";",
                };
                var reader = new StreamReader(file, Encoding.GetEncoding(28591));
                var csv = new CsvReader(reader, config);
                var atendimentos = csv.GetRecords<CnaeCsvDto>();
                foreach(var atendimento in atendimentos)
                {
                    Console.WriteLine(atendimento.Code);
                    Console.WriteLine(atendimento.Description);
                }
            }
            return "";
            

            
        }
    }
}