using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Managers;
using Firma.Models.Values.Legal;
using Firma.Services;
using Firma.Tests.Common;
using Firma.Tests.Common.TestUtils;
using Firma.Tests.Integration.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Testcontainers.PostgreSql;

namespace Firma.Tests.Integration.Managers
{
    public class CnaeManagerTest : DbFixture
    {

        [Test]
        public async Task ImportDataTest()
        {
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockDownloadFile();

            ReceitaFederalService rfService = new(rfClient);
            var loggerCsvParser = Mock.Of<ILogger<CsvParserService>>();
            CsvParserService cnaeParser = new(loggerCsvParser);
            var loggerCnaeManager = Mock.Of<ILogger<CnaeManager>>();
            var mockSet = new Mock<DbSet<Cnae>>();

            CnaeManager cnaeManager = new(_dbContext, cnaeParser, rfService, loggerCnaeManager);
            await cnaeManager.ImportData();
            var cnae = await _dbContext.Cnae.FirstOrDefaultAsync(c => c.Code == "0111301");

            Assert.AreEqual(cnae.Code, "0111301");
        }
    }
}