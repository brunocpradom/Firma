using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Firma.Dtos.Csv
{
    public class CompanyCsvDto
    {
        [Index(0)]
        public required string BasicTaxId { get; set; }
        [Index(1)]
        public required string RegisteredName { get; set; }
        [Index(2)]
        public required string LegalNature { get; set; }
        [Index(3)]
        public string? QualificationOfPersonInCharge { get; set; }
        [Index(4)]
        public string? ShareCapital { get; set; }
        [Index(5)]
        public required string CompanySize { get; set; }
        [Index(6)]
        public string? ResponsibleFederalEntity { get; set; }
    }
}