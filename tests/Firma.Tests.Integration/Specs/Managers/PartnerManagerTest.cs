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
    public class PartnerManagerTest : DbFixture
    {
        [SetUp]
        public async Task Setup()
        {
            var qualificationBuilder = new QualificationBuilder()
                .WithCode("49")
                .Generate();
            var qualificationBuilder2 = new QualificationBuilder()
                .WithCode("00")
                .Generate();
            var countryBuilder = new CountryBuilder()
                .WithCode("105")
                .Generate();
            var companyBuilder = new CompanyBuilder()
                .WithBasicTaxId("46204351")
                .Generate();
            var companyBuilder2 = new CompanyBuilder()
                .WithBasicTaxId("46204403")
                .Generate();
            var companyBuilder3 = new CompanyBuilder()
                .WithBasicTaxId("46204413")
                .Generate();
            var companyBuilder4 = new CompanyBuilder()
                .WithBasicTaxId("46204456")
                .Generate();
            await _dbContext.AddRangeAsync(qualificationBuilder, qualificationBuilder2, countryBuilder,
                companyBuilder, companyBuilder2, companyBuilder3, companyBuilder4);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Socios0.zip");
            var loggerPartnersManager = Mock.Of<ILogger<PartnersManager>>();
            PartnersManager partnersManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerPartnersManager);
            await partnersManager.ImportData();

            var partner = await _dbContext.Partner.FirstOrDefaultAsync(c => c.Company.BasicTaxId == "46204351");
            partner!.Name.Should().Be("RUTHIELLI DOS SANTOS ORTIZ");
            partner!.DocumentNumber.Should().Be("***627370**");
        }
    }
}