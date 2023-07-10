using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Managers;
using Firma.Models.Values.Legal;
using Firma.Services;
using Firma.Tests.Common.TestUtils;
using Firma.Tests.Integration.Fixtures;
using Firma.Tests.Integration.TestUtils.Mocks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WireMock.Server;
using WireMock.RequestBuilders;
using Microsoft.Extensions.Configuration;

namespace Firma.Tests.Integration.Specs.Managers
{
    public class CnaeManagerTest : DbFixture
    {

        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Cnaes.zip");
            var loggerCnaeManager = Mock.Of<ILogger<CnaeManager>>();
            var loggerCsvParser = Mock.Of<ILogger<CsvParserService>>();

            ReceitaFederalService rfService = new(receitaFederalClientMock());
            CsvParserService cnaeParser = new(loggerCsvParser);
            CnaeManager cnaeManager = new(_dbContext, cnaeParser, rfService, loggerCnaeManager);

            await cnaeManager.ImportData();
            var cnae = await _dbContext.Cnae.FirstOrDefaultAsync(c => c.Code == "0111301");
            cnae!.Code.Should().Be("0111301");

        }
    }
}