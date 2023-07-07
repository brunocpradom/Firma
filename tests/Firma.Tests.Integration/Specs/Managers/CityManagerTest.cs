using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Managers;
using Firma.Models.Values.Contact;
using Firma.Services;
using Firma.Tests.Common.TestUtils;
using Firma.Tests.Integration.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Firma.Tests.Integration.Specs.Managers
{
    public class CityManagerTest : DbFixture
    {
        [Test]
        public async Task ImportDataTest()
        {
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockDownloadFile("Municipios.zip");
            ReceitaFederalService rfService = new(rfClient);
            var loggerCsvParser = Mock.Of<ILogger<CsvParserService>>();
            CsvParserService cnaeParser = new(loggerCsvParser);
            var loggerCityManager = Mock.Of<ILogger<CityManager>>();
            var mockSet = new Mock<DbSet<City>>();
            CityManager cityManager = new(_dbContext, cnaeParser, rfService, loggerCityManager);
            await cityManager.ImportData();
            //var city = await _dbContext.City.FirstOrDefaultAsync(c => c.Code == "0001");
            var city = await _dbContext.City.AnyAsync();
            Console.WriteLine("city");
            Console.WriteLine(city);
        }
    }
}