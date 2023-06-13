using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;


namespace Firma.Dtos.Csv
{
    public class CityCsvDto
    {
        public required string Code { get; set; }
        public required string Description { get; set; }
    }
}