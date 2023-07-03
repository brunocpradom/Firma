using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Firma.Services;
using System.Net;
using RichardSzalay.MockHttp;
using Moq;
using System.Net.Http.Json;
using Moq.Protected;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;
using Firma.Tests.TestUtils;
using Firma.Models;
using System.Reflection;

namespace Firma.Tests.Specs.Services
{
    public class ReceitaFederalClientTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetMainLinksTest()
        {
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockGetMainLinks();
            var response = await rfClient.GetMainLinks();
            Assert.AreEqual(response.Count(), 37);
        }

        [Test]
        public async Task GetTaxRegimeLinks()
        {
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockGetTaxRegimeLinks();
            var response = await rfClient.GetTaxRegimeLinks();
            Assert.AreEqual(response.Count(), 4);
        }

        [Test]
        public async Task DownloadFileTest()
        {
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockDownloadFile();
            var link = "http://200.152.38.155/CNPJ/cnaes.zip";
            var target = DownloadTarget.Cnae;

            var destinationDirectory = Path.Combine(Path.GetTempPath(), target.ToString());
            Directory.CreateDirectory(destinationDirectory);
            var response = await rfClient.DownloadFile(link, destinationDirectory);
            Assert.AreEqual(response, Path.Combine(destinationDirectory, link.Split("/").Last()));
        }
    }
}