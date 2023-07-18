using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Managers;
using Firma.Tests.Integration.Fixtures;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Firma.Tests.Integration.Specs.Managers
{
    public class LegalNatureManagerTest : DbFixture
    {
        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Naturezas.zip");
            var loggerLegalNatureManager = Mock.Of<ILogger<LegalNatureManager>>();
            LegalNatureManager cnaeManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerLegalNatureManager);

            await cnaeManager.ImportData();
            var legalNature = await _dbContext.LegalNature.FirstOrDefaultAsync(c => c.Code == "3271");
            legalNature!.Code.Should().Be("3271");
            legalNature!.Description.Should().Be("Órgão de Direção Local de Partido Político");
        }
    }
}