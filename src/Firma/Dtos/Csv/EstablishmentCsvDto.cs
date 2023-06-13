using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Dtos.Csv
{
    public class EstablishmentCsvDto
    {
        public required string BasicTaxId { get; set; }
        public required string OrderTaxId { get; set; }
        public required string DVTaxId { get; set; }
        public required string Identifier { get; set; }
        public string? TradeName { get; set; }
        public string? CadastralSituation { get; set; }
        public DateOnly  CadastralSituationDate { get; set; }
        public string? CadastralSituationMotive { get; set; }
        public string? ForeignCityName { get; set; }
        public string? Country { get; set; }
        public DateOnly ActivityStartDate { get; set; }
        public required string MainCnae { get; set; }
        public string? SecondaryCnae { get; set; }
        public required string StreetType { get; set; }
        public required string StreetAddress { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? Neighborhood { get; set; }
        public required string ZipCode { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
        public string? DDD1 { get; set; }
        public string? Telephone1 { get; set; }
        public string? DDD2 { get; set; }
        public string? Telephone2 { get; set; }
        public string? FaxDDD { get; set; }
        public string? FaxNumber { get; set; }
        public string? Email { get; set; }
        public string? SpecialSituation { get; set; }
        public DateOnly SpecialSituationDate { get; set; }
    }
}