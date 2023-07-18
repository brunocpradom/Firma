using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Managers;
using Firma.Services;
using Firma.Tests.Integration.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Firma.Tests.Integration.Specs.Managers
{
    public class CountryManagerTest : DbFixture
    {
        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Paises.zip");
            var loggerCountryManager = Mock.Of<ILogger<CountryManager>>();
            CountryManager countryManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerCountryManager);
            await countryManager.ImportData();

            var country = await _dbContext.Country.FirstOrDefaultAsync(c => c.Code == "013");
            country!.Code.Should().Be("013");
            country!.Name.Should().Be("AFEGANISTAO");
        }
    }
}