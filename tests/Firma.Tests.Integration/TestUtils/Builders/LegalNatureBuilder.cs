using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Values.Legal;
using FakeItEasy;
using Bogus;

namespace Firma.Tests.Integration.TestUtils.Builders
{
    public sealed class LegalNatureBuilder : Faker<LegalNature>
    {
        public LegalNatureBuilder()
        {
            RuleFor(l => l.Code, f => f.Random.String2(2, 2).ToUpper());
            RuleFor(l => l.Description, f => f.Random.String2(10, 10).ToUpper());
        }
        public LegalNatureBuilder WithCode(string code)
        {
            RuleFor(l => l.Code, code);
            return this;
        }
        public LegalNatureBuilder WithDescription(string description)
        {
            RuleFor(l => l.Description, description);
            return this;
        }
    }
}