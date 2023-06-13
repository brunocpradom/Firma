using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Dtos.Csv
{
    public class PartnerCsvDto
    {
        public required string BasicTaxId { get; set; }
        public required string Identifier { get; set; }
        public required string Name { get; set; }
        public required string DocumentNumber { get; set; }
        public required string Qualification { get; set; }
        public DateOnly CompanyJoiningDate { get; set; }
        public required string Country { get; set; }
        public string LegalRepresentative { get; set; } = String.Empty;
        public string RepresentativeName { get; set; } = String.Empty;
        public string RepresentativeQualification { get; set; } = String.Empty;
        public required string AgeGroup { get; set; }

    }
}