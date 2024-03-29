using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Values.Contact;
using Firma.Models.Values.Companies;
using Firma.Models.Values.Legal;

namespace Firma.Models.Entities
{
    public class Establishment
    {
        public int Id { get; set; }
        public required Company Company { get; set; }
        public required string TaxId { get; set; }
        public required Identifier Identifier { get; set; }
        public string? TradeName { get; set; }
        public DateOnly? ActivityStartDate { get; set; }
        public required CadastralSituation CadastralSituation { get; set; }
        public required MainCnae MainCnae { get; set; }
        public SecondaryCnaes? SecondaryCnaes { get; set; }
        public required Address Address { get; set; }
        public List<Telephone>? Telephone { get; set; }
        public List<Email>? Email { get; set; }

    }
}