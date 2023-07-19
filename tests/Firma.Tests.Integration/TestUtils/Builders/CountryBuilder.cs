using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Firma.Models.Values.Contact;

namespace Firma.Tests.Integration.TestUtils.Builders
{
    public class CountryBuilder : Faker<Country>
    {
        public CountryBuilder()
        {
            RuleFor(c => c.Name, f => f.Random.String2(50));
            RuleFor(c => c.Code, f => f.Random.String2(2, "0123456789"));
        }
        public CountryBuilder WithName(string name)
        {
            RuleFor(c => c.Name, name);
            return this;
        }
        public CountryBuilder WithCode(string code)
        {
            RuleFor(c => c.Code, code);
            return this;
        }
    }
}