using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Firma.Models.Values.TaxationModel;

namespace Firma.Tests.Integration.TestUtils.Builders
{
    public class TaxRegimeBuilder : Faker<TaxRegime>
    {
        public TaxRegimeBuilder()
        {
            RuleFor(t => t.Company, f => null);
            RuleFor(t => t.CompanyId, f => f.Random.Int(0, 100000));
            RuleFor(t => t.Mei, f => null);
            RuleFor(t => t.Simples, f => null);
            RuleFor(t => t.Lucro, f => null);
        }
    }
}