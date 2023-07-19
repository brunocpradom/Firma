using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Firma.Models.Values;

namespace Firma.Tests.Integration.TestUtils.Builders
{
    public class QualificationBuilder : Faker<Qualification>
    {
        public QualificationBuilder()
        {
            RuleFor(q => q.Code, f => f.Random.String2(2, 2).ToUpper());
            RuleFor(q => q.Description, f => f.Random.String2(10, 10).ToUpper());
        }
        public QualificationBuilder WithCode(string code)
        {
            RuleFor(q => q.Code, code);
            return this;
        }
        public QualificationBuilder WithDescription(string description)
        {
            RuleFor(q => q.Description, description);
            return this;
        }
    }
}