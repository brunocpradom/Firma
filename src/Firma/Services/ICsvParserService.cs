using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Services
{
    public interface ICsvParserService
    {
        public IEnumerable<CsvDto> ProcessCsv<CsvDto>(string pathDirectory);
        public IEnumerable<CsvDto> ProcessCsvWithHeaders<CsvDto>(string pathDirectory);
    }
}