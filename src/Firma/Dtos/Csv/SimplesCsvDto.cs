using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Firma.Dtos.Csv
{
    public class SimplesCsvDto
    {
        [Index(0)]
        public required string BasicTaxId { get; set; }
        [Index(1)]
        public string? OptionForSimple { get; set; }
        [Index(2)]
        public string? OptionForSimpleInclusionDate { get; set; }
        [Index(3)]
        public string? OptionForSimpleExclusionDate { get; set; }
        [Index(4)]
        public string? OptionForMei { get; set; }
        [Index(5)]
        public string? OptionForMeiInclusionDate { get; set; }
        [Index(6)]
        public string? OptionForMeiExclusionDate { get; set; }
    }
}