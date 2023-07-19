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
    public class CompanyManagerTest : DbFixture
    {
        [SetUp]
        public async Task Setup()
        {
            var legalNature = new LegalNatureBuilder()
                .WithCode("2135")
                .Generate();
            var legalNature2 = new LegalNatureBuilder()
                .WithCode("2062")
                .Generate();
            var legalNature3 = new LegalNatureBuilder()
                .WithCode("2305")
                .Generate();

            var qualification = new QualificationBuilder()
                .WithCode("50")
                .Generate();
            var qualification2 = new QualificationBuilder()
                .WithCode("65")
                .Generate();
            var qualification3 = new QualificationBuilder()
                .WithCode("49")
                .Generate();

            await _dbContext.AddRangeAsync(legalNature, legalNature2, legalNature3, qualification, qualification2, qualification3);
            await _dbContext.SaveChangesAsync();
        }
        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Empresas0.zip");
            var loggerCompanyManager = Mock.Of<ILogger<CompanyManager>>();
            CompanyManager companyManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerCompanyManager);
            await companyManager.ImportData();

            var company = await _dbContext.Company.FirstOrDefaultAsync(c => c.BasicTaxId == "41273597");
            company!.BasicTaxId.Should().Be("41273597");
            company!.RegisteredName.Should().Be("PACHARRUS QUEIROZ DA COSTA E SILVA 03618384335");
        }
    }
}