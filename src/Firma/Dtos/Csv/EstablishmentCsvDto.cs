using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Firma.Dtos.Csv
{
    public class EstablishmentCsvDto
    {
        [Index(0)]
        public required string BasicTaxId { get; set; }
        [Index(1)]
        public required string OrderTaxId { get; set; }
        [Index(2)]
        public required string DVTaxId { get; set; }
        [Index(3)]
        public required string Identifier { get; set; }
        [Index(4)]
        public string TradeName { get; set; } = string.Empty;
        [Index(5)]
        public string CadastralSituation { get; set; } = string.Empty;
        [Index(6)]
        public string CadastralSituationDate { get; set; } = string.Empty;
        [Index(7)]
        public string CadastralSituationReason { get; set; } = string.Empty;
        [Index(8)]
        public string ForeignCityName { get; set; } = string.Empty;
        [Index(9)]
        public string Country { get; set; } = string.Empty;
        [Index(10)]
        public string ActivityStartDate { get; set; } = string.Empty;
        [Index(11)]
        public required string MainCnae { get; set; }
        [Index(12)]
        public string? SecondaryCnae { get; set; } = string.Empty;
        [Index(13)]
        public required string StreetType { get; set; }
        [Index(14)]
        public required string StreetAddress { get; set; }
        [Index(15)]
        public required string Number { get; set; }
        [Index(16)]
        public string Complement { get; set; } = string.Empty;
        [Index(17)]
        public required string Neighborhood { get; set; }
        [Index(18)]
        public required string ZipCode { get; set; }
        [Index(19)]
        public required string State { get; set; }
        [Index(20)]
        public required string City { get; set; }
        [Index(21)]
        public string DDD1 { get; set; } = string.Empty;
        [Index(22)]
        public string Telephone1 { get; set; } = string.Empty;
        [Index(23)]
        public string DDD2 { get; set; } = string.Empty;
        [Index(24)]
        public string Telephone2 { get; set; } = string.Empty;
        [Index(25)]
        public string FaxDDD { get; set; } = string.Empty;
        [Index(26)]
        public string FaxNumber { get; set; } = string.Empty;
        [Index(27)]
        public string Email { get; set; } = string.Empty;
        [Index(28)]
        public string SpecialSituation { get; set; } = string.Empty;
        [Index(29)]
        public string SpecialSituationDate { get; set; } = string.Empty;
    }
}