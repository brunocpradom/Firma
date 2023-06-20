using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Firma.Dtos.Csv
{
    public class LucroCsvDto
    {
        [Index(0)]
        public int Year { get; set; }
        [Index(1)]
        public required string TaxId { get; set; } //11.111.111/0001-91.
        [Index(2)]
        public required string ScrTaxId { get; set; }
        [Index(3)]
        public required string FormOfTaxation { get; set; }
        [Index(4)]
        public int AmountOfBookkeeping { get; set; } // quantidade de escriturações
    }
}