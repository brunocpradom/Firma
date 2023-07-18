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
    public class CadastralSituationReasonManagerTest : DbFixture
    {
        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Motivos.zip");
            var loggerCadastralReasonManager = Mock.Of<ILogger<CadastralSituationReasonManager>>();
            CadastralSituationReasonManager cadastralSituationManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerCadastralReasonManager);
            await cadastralSituationManager.ImportData();

            var cadastralReason = await _dbContext.CadastralSituationReason.FirstOrDefaultAsync(c => c.Code == "02");
            cadastralReason!.Code.Should().Be("02");
            cadastralReason!.Description.Should().Be("INCORPORACAO");
        }
    }
}