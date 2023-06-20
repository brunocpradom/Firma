using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Firma.Dtos.Csv
{
    public class PartnerCsvDto
    {
        [Index(0)]
        public required string BasicTaxId { get; set; }
        [Index(1)]
        public required string Identifier { get; set; }
        [Index(2)]
        public required string Name { get; set; }
        [Index(3)]
        public required string DocumentNumber { get; set; }
        [Index(4)]
        public required string Qualification { get; set; }
        [Index(5)]
        public DateOnly CompanyJoiningDate { get; set; }
        [Index(6)]
        public required string Country { get; set; }
        [Index(7)]
        public string LegalRepresentative { get; set; } = String.Empty;
        [Index(8)]
        public string RepresentativeName { get; set; } = String.Empty;
        [Index(9)]
        public string RepresentativeQualification { get; set; } = String.Empty;
        [Index(10)]
        public required string AgeGroup { get; set; }

    }
}