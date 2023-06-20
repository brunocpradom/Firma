using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Firma.Dtos.Csv
{
    public class CountryCsvDto
    {
        [Index(0)]
        public required string Code { get; set; }
        [Index(1)]
        public required string Description { get; set; }
    }
}