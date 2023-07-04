using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models;
using Firma.Services;
using Firma.Tests.Common;
using Firma.Tests.TestUtils;
using NUnit.Framework;

namespace Firma.Tests.Specs.Services
{
    public class ReceitaFederalServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task DownloadTest()
        {
            MockFileProvider mockFileProvider = new();
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockDownloadFile();
            ReceitaFederalService rfService = new(rfClient);
            var target = DownloadTarget.Cnae;
            var response = await rfService.Download(target);
            Assert.AreEqual(response, Path.Combine(Path.GetTempPath(), target.ToString()));
        }
    }
}