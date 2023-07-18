using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Values;
using Firma.Models.Values.Contact;
using Firma.Models.Values.Partner;

namespace Firma.Models.Entities
{
    public class Partner
    {
        public int Id { get; set; }
        public required Company Company { get; set; }
        public required PartnerIdentifier Identifier { get; set; }
        public string Name { get; set; } = String.Empty;
        public string DocumentNumber { get; set; } = String.Empty; // cpf ou cnpj
        public Qualification? Qualification { get; set; }
        public AgeGroup? AgeGroup { get; set; }
        public DateOnly CompanyJoiningDate { get; set; }
        public Country? Country { get; set; }
        public string LegalRepresentative { get; set; } = String.Empty;
        public string RepresentativeName { get; set; } = String.Empty;
        public Qualification? RepresentativeQualification { get; set; }

    }
}