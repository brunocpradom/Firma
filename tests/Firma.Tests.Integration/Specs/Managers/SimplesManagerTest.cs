using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Managers;
using Firma.Tests.Integration.Fixtures;
using Firma.Tests.Integration.TestUtils.Builders;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Firma.Tests.Integration.Specs.Managers
{
    public class SimplesManagerTest : DbFixture
    {
        [SetUp]
        public async Task Setup()
        {
            var companyBuilder = new CompanyBuilder()
                .WithBasicTaxId("04549729")
                .Generate();
            var companyBuilder2 = new CompanyBuilder()
                .WithBasicTaxId("04549730")
                .Generate();
            var companyBuilder3 = new CompanyBuilder()
                .WithBasicTaxId("04549731")
                .Generate();
            var companyBuilder4 = new CompanyBuilder()
                .WithBasicTaxId("04549736")
                .Generate();
            await _dbContext.AddRangeAsync(companyBuilder, companyBuilder2, companyBuilder3, companyBuilder4);
            await _dbContext.SaveChangesAsync();
        }
        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Simples.zip");
            var loggerSimplesManager = Mock.Of<ILogger<SimplesManager>>();
            SimplesManager simplesManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerSimplesManager);

            await simplesManager.ImportData();
            var taxRegime = await _dbContext.TaxRegime.FirstOrDefaultAsync(c => c.Company!.BasicTaxId == "04549729");
            taxRegime!.Company!.BasicTaxId.Should().Be("04549729");

        }
    }
}