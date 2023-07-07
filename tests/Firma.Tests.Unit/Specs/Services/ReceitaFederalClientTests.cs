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
using Firma.Models;
using System.Reflection;
using Firma.Tests.Common.TestUtils;
using FluentAssertions;

namespace Firma.Tests.Specs.Services
{
    public class ReceitaFederalClientTests
    {
        [Test]
        public async Task GetMainLinksTest()
        {
            var rfClient = ReceitaFederalClientMock.MockGetMainLinks();
            var response = await rfClient.GetMainLinks();
            response.Count().Should().Be(37);
        }

        [Test]
        public async Task GetTaxRegimeLinks()
        {
            var rfClient = ReceitaFederalClientMock.MockGetTaxRegimeLinks();
            var response = await rfClient.GetTaxRegimeLinks();
            response.Count().Should().Be(4);
        }

        [Test]
        public async Task DownloadFileTest()
        {
            var rfClient = ReceitaFederalClientMock.MockDownloadFile();
            var link = "http://200.152.38.155/CNPJ/Cnaes.zip";
            var target = DownloadTarget.Cnae;

            var destinationDirectory = Path.Combine(Path.GetTempPath(), target.ToString());
            Directory.CreateDirectory(destinationDirectory);
            var response = await rfClient.DownloadFile(link, destinationDirectory);

            response.Should().Be(Path.Combine(destinationDirectory, link.Split("/").Last()));
        }
    }
}