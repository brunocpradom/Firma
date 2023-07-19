using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Firma.Models.Values.Companies;

namespace Firma.Tests.Integration.TestUtils.Builders
{
    public class CadastralSituationReasonBuilder : Faker<CadastralSituationReason>
    {
        public CadastralSituationReasonBuilder()
        {
            RuleFor(c => c.Code, f => f.Random.String2(2, "0123456789"));
            RuleFor(c => c.Description, f => f.Random.String2(50));
        }
        public CadastralSituationReasonBuilder WithCode(string code)
        {
            RuleFor(c => c.Code, code);
            return this;
        }
        public CadastralSituationReasonBuilder WithDescription(string description)
        {
            RuleFor(c => c.Description, description);
            return this;
        }
    }
}