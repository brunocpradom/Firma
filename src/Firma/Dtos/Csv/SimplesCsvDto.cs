using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Dtos.Csv
{
    public class SimplesCsvDto
    {
        public required string BasicTaxId { get; set; }
        public string? OptionForSimple { get; set; }
        public DateOnly OptionForSimpleInclusionDate { get; set; }
        public DateOnly OptionForSimpleExclusionDate { get; set; }
        public string? OptionForMei { get; set; }
        public DateOnly OptionForMeiInclusionDate { get; set; }
        public DateOnly OptionForMeiExclusionDate { get; set; }
    }
}