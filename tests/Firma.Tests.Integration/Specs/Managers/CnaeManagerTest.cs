using Firma.Managers;
using Firma.Services;
using Firma.Tests.Common.TestUtils;
using Firma.Tests.Integration.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Firma.Tests.Integration.Specs.Managers
{
    public class CnaeManagerTest : DbFixture
    {
        [Test]
        public async Task ImportDataTest()
        {
            var loggerCsvParser = Mock.Of<ILogger<CsvParserService>>();
            var loggerCnaeManager = Mock.Of<ILogger<CnaeManager>>();

            ReceitaFederalClient rfClient = ReceitaFederalClientMock.MockDownloadFile();
            ReceitaFederalService rfService = new(rfClient);
            CsvParserService cnaeParser = new(loggerCsvParser);

            CnaeManager cnaeManager = new(_dbContext, cnaeParser, rfService, loggerCnaeManager);
            await cnaeManager.ImportData();
            var cnae = await _dbContext.Cnae.FirstAsync(c => c.Code == "0111301");

            cnae.Code.Should().Be("0111301");
        }
    }
}