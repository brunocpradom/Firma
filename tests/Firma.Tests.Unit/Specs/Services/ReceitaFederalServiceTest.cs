using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models;
using Firma.Services;
using Firma.Tests.Common;
using Firma.Tests.Common.TestUtils;
using FluentAssertions;
using NUnit.Framework;

namespace Firma.Tests.Specs.Services
{
    public class ReceitaFederalServiceTest
    {

        [Test]
        public async Task DownloadTest()
        {
            MockFileProvider mockFileProvider = new();
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockDownloadFile("cnaes.zip");
            ReceitaFederalService rfService = new(rfClient);
            var target = DownloadTarget.Cnae;
            var response = await rfService.Download(target);
            response.Should().Be(Path.Combine(Path.GetTempPath(), target.ToString()));
        }
    }
}