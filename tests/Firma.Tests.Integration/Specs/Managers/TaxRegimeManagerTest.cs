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
    public class TaxRegimeManagerTest : DbFixture
    {
        [SetUp]
        public async Task Setup()
        {
            var companyBuilder = new CompanyBuilder()
                .WithBasicTaxId("00055699")
                .Generate();
            var companyBuilder2 = new CompanyBuilder()
                .WithBasicTaxId("00071760")
                .Generate();
            var companyBuilder3 = new CompanyBuilder()
                .WithBasicTaxId("00146791")
                .Generate();
            var companyBuilder4 = new CompanyBuilder()
                .WithBasicTaxId("00287036")
                .Generate();
            var companyBuilder5 = new CompanyBuilder()
                .WithBasicTaxId("00360051")
                .Generate();
            var companyBuilder6 = new CompanyBuilder()
                .WithBasicTaxId("00402319")
                .Generate();
            _dbContext.AddRange(companyBuilder, companyBuilder2, companyBuilder3,
                companyBuilder4, companyBuilder5, companyBuilder6);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task ImportDataTesta()
        {
            CreateGetTaxRegimeLinkStub();
            CreateDownloadFileStub("Lucro Arbitrado.zip");
            var loggerTaxRegimeManager = Mock.Of<ILogger<TaxRegimeManager>>();
            TaxRegimeManager taxRegimeManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerTaxRegimeManager);

            await taxRegimeManager.ImportData();
            var taxRegime = await _dbContext.TaxRegime.FirstOrDefaultAsync(c => c.Company.BasicTaxId == "00055699");
            taxRegime!.Lucro!.FormOfTaxation.Should().Be("LUCRO ARBITRADO");
            taxRegime!.Lucro.Year.Should().Be(2021);
        }
    }
}