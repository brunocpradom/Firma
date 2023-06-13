using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Dtos.Csv
{
    public class CompanyCsvDto
    {
        public required string BasicTaxId { get; set; }
        public required string RegisteredName { get; set; }
        public required string LegalNature { get; set; }
        public string? QualificationOfPersonInCharge { get; set; }
        public int ShareCapital { get; set; }
        public required string CompanySize { get; set; }
        public string? ResponsibleFederalEntity { get; set; }
    }
}