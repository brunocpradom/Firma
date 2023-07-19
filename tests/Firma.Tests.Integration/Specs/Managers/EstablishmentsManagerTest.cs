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
    public class EstablishmentsManagerTest : DbFixture
    {
        [SetUp]
        public async Task Setup()
        {
            var countryBuilder = new CountryBuilder()
                .WithCode("105")
                .Generate();
            var cityBuilder = new CityBuilder()
                .WithCode("4447")
                .Generate();
            var cityBuilder2 = new CityBuilder()
                .WithCode("7107")
                .Generate();
            var cityBuilder3 = new CityBuilder()
                .WithCode("2051")
                .Generate();
            var cityBuilder4 = new CityBuilder()
                .WithCode("6001")
                .Generate();
            var cadastralSituationReasonBuilder = new CadastralSituationReasonBuilder()
                .WithCode("00")
                .Generate();
            var cadastralSituationReasonBuilder2 = new CadastralSituationReasonBuilder()
                .WithCode("01")
                .Generate();
            var cadastralSituationReasonBuilder3 = new CadastralSituationReasonBuilder()
                .WithCode("63")
                .Generate();
            var cnaeBuilder = new CnaeBuilder()
                .WithCode("4783101")
                .Generate();
            var cnaeBuilder2 = new CnaeBuilder()
                .WithCode("5620103")
                .Generate();
            var cnaeBuilder3 = new CnaeBuilder()
                .WithCode("5611201")
                .Generate();
            var cnaeBuilder4 = new CnaeBuilder()
                .WithCode("4713002")
                .Generate();
            var cnaeBuilder5 = new CnaeBuilder()
                .WithCode("5620101")
                .Generate();
            var companyBuilder = new CompanyBuilder()
                .WithBasicTaxId("34841863")
                .Generate();
            var companyBuilder2 = new CompanyBuilder()
                .WithBasicTaxId("34841373")
                .Generate();
            var companyBuilder3 = new CompanyBuilder()
                .WithBasicTaxId("34841384")
                .Generate();
            var companyBuilder4 = new CompanyBuilder()
                .WithBasicTaxId("34841393")
                .Generate();
            await _dbContext.AddRangeAsync(
                companyBuilder, companyBuilder2, companyBuilder3, companyBuilder4,
                cnaeBuilder, cnaeBuilder2, cnaeBuilder3, cnaeBuilder4, cnaeBuilder5,
                cadastralSituationReasonBuilder, cadastralSituationReasonBuilder2,
                cadastralSituationReasonBuilder3, cityBuilder, cityBuilder2,
                cityBuilder3, cityBuilder4, countryBuilder);
            await _dbContext.SaveChangesAsync();
        }

        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Estabelecimentos0.zip");
            var loggerEstablishmentManager = Mock.Of<ILogger<EstablishmentsManager>>();
            EstablishmentsManager establishmentsManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerEstablishmentManager);
            await establishmentsManager.ImportData();

            var establishment = await _dbContext.Establishment.FirstOrDefaultAsync(c => c.TaxId == "34841373000107");
            establishment!.TaxId.Should().Be("34841373000107");
            establishment!.TradeName.Should().Be("ALESSANDRO MARCOS BAZOLLI");
        }
    }
}