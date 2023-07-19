using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Firma.Models.Values.Legal;

namespace Firma.Tests.Integration.TestUtils.Builders
{
    public class CnaeBuilder : Faker<Cnae>
    {
        public CnaeBuilder()
        {
            RuleFor(c => c.Code, f => f.Random.String2(7, "0123456789"));
            RuleFor(c => c.Description, f => f.Random.String2(50));
        }
        public CnaeBuilder WithCode(string code)
        {
            RuleFor(c => c.Code, code);
            return this;
        }
        public CnaeBuilder WithDescription(string description)
        {
            RuleFor(c => c.Description, description);
            return this;
        }
    }
}