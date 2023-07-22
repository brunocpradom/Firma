using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Values;
using Firma.Models.Values.Companies;
using Firma.Models.Values.Legal;
using Firma.Models.Values.TaxationModel;

namespace Firma.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public required string BasicTaxId { get; set; }
        public required string RegisteredName { get; set; }
        public LegalNature? LegalNature { get; set; }
        public string? ShareCapital { get; set; }
        public required CompanySize CompanySize { get; set; }
        public required TaxRegime TaxRegime { get; set; }
        public string? ResponsibleFederalEntity { get; set; }
        public Qualification? QualificationOfPersonInCharge { get; set; }


    }
}