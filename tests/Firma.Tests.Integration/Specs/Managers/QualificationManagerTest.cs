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
    public class QualificationManagerTest : DbFixture
    {
        [Test]
        public async Task ImportDataTest()
        {
            CreateDownloadFileStub("Qualificacoes.zip");
            var loggerQualificationManager = Mock.Of<ILogger<QualificationManager>>();
            QualificationManager qualificationManager = new(_dbContext, csvParserServiceMock, receitaFederalServiceMock, loggerQualificationManager);

            await qualificationManager.ImportData();
            var qualification = await _dbContext.Qualification.FirstOrDefaultAsync(c => c.Code == "05");
            qualification!.Code.Should().Be("05");
            qualification!.Description.Should().Be("Administrador");
        }
    }
}