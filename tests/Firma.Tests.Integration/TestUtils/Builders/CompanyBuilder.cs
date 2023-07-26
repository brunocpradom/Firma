using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Firma.Models.Entities;
using Firma.Models.Values;
using Firma.Models.Values.Companies;
using Firma.Models.Values.Legal;
using Firma.Models.Values.TaxationModel;

namespace Firma.Tests.Integration.TestUtils.Builders
{
    public class CompanyBuilder : Faker<Company>
    {
        public CompanyBuilder()
        {
            RuleFor(c => c.BasicTaxId, f => f.Random.AlphaNumeric(14));
            RuleFor(c => c.RegisteredName, f => f.Company.CompanyName());
            RuleFor(c => c.LegalNature, f => new LegalNatureBuilder().Generate());
            RuleFor(c => c.ShareCapital, f => f.Random.String2(10, 10));
            RuleFor(c => c.CompanySize, f => f.Random.Enum<CompanySize>());
            RuleFor(c => c.TaxRegime, f => new TaxRegimeBuilder().Generate());
            RuleFor(c => c.ResponsibleFederalEntity, f => f.Random.String2(10, 10));
            RuleFor(c => c.QualificationOfPersonInCharge, f => new QualificationBuilder().Generate());
        }
        public CompanyBuilder WithBasicTaxId(string basicTaxId)
        {
            RuleFor(c => c.BasicTaxId, f => basicTaxId);
            return this;
        }
        public CompanyBuilder WithRegisteredName(string registeredName)
        {
            RuleFor(c => c.RegisteredName, f => registeredName);
            return this;
        }
        public CompanyBuilder WithLegalNature(LegalNature legalNature)
        {
            RuleFor(c => c.LegalNature, f => legalNature);
            return this;
        }
        public CompanyBuilder WithShareCapital(string shareCapital)
        {
            RuleFor(c => c.ShareCapital, f => shareCapital);
            return this;
        }
        public CompanyBuilder WithCompanySize(CompanySize companySize)
        {
            RuleFor(c => c.CompanySize, f => companySize);
            return this;
        }
        public CompanyBuilder WithTaxRegime(TaxRegime taxRegime)
        {
            RuleFor(c => c.TaxRegime, f => taxRegime);
            return this;
        }
        public CompanyBuilder WithResponsibleFederalEntity(string responsibleFederalEntity)
        {
            RuleFor(c => c.ResponsibleFederalEntity, f => responsibleFederalEntity);
            return this;
        }
        public CompanyBuilder WithQualificationOfPersonInCharge(Qualification qualificationOfPersonInCharge)
        {
            RuleFor(c => c.QualificationOfPersonInCharge, f => qualificationOfPersonInCharge);
            return this;
        }
    }
}