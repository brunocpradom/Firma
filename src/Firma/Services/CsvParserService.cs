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
using Firma.Models.Values.Legal;

namespace Firma.Services
{
    public class CsvParserService : ICsvParserService
    {
        private ILogger<CsvParserService> _logger;

        public CsvParserService(ILogger<CsvParserService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<CsvDto> ProcessCsv<CsvDto>(string pathDirectory)
        {
            _logger.LogInformation("Start csv parsing!");

            var files = Directory.GetFiles(pathDirectory);
            foreach (var file in files)
            {
                _logger.LogInformation(file);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = ";",
                    MissingFieldFound = null
                };
                using (var reader = new StreamReader(file, Encoding.GetEncoding(28591)))
                {
                    var csv = new CsvReader(reader, config);
                    var records = csv.GetRecords<CsvDto>();

                    foreach (var record in records)
                    {
                        yield return record;
                    }
                }

            }
        }
    }
}