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

        // [Test]
        // public async Task AssertGetMainLinks()
        // {
        //     CreateDownloadFileStub();
        //     var loggerRfClient = Mock.Of<ILogger<ReceitaFederalClient>>();
        //     HttpClient httpClient = new();

        //     string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        //     Console.WriteLine("rootpath");
        //     Console.WriteLine(rootPath);
        //     var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
        //     var oneAboveDirectory = Directory.GetParent(currentDirectory!.ToString());
        //     var twoAboveDirectory = Directory.GetParent(oneAboveDirectory!.ToString());
        //     Console.WriteLine(Path.Combine(twoAboveDirectory!.ToString(), "appsettings.Development.json"));
        //     var configuration = new ConfigurationBuilder()
        //         .AddJsonFile(Path.Combine(twoAboveDirectory!.ToString(), "appsettings.Development.json"))
        //         .Build();

        //     ReceitaFederalClient rfClient = new(loggerRfClient, httpClient, configuration);
        //     var links = await rfClient.GetMainLinks();
        //     Console.WriteLine("links");
        //     Console.WriteLine(links);
        //     Console.WriteLine(links.Count());
        // }
        [Test]
        public async Task ImportDataTest()
        {
            //File.Copy(sourceFilePath, destinationFilePath, true);

            // ReceitaFederalClientMock rfClientMock = new();
            // ReceitaFederalClient rfClient = rfClientMock.MockDownloadFile("cnaes.zip");
            //MockReceitaFederalClient mockReceitaFederalClient = new();
            //var rfClientMock = mockReceitaFederalClient.rfClientMock("cnaes.zip");
            CreateDownloadFileStub();
            var loggerRfClient = Mock.Of<ILogger<ReceitaFederalClient>>();
            HttpClient httpClient = new();

            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            var oneAboveDirectory = Directory.GetParent(currentDirectory!.ToString());
            var twoAboveDirectory = Directory.GetParent(oneAboveDirectory!.ToString());
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(twoAboveDirectory!.ToString(), "appsettings.Development.json"))
                .Build();

            ReceitaFederalClient rfClient = new(loggerRfClient, httpClient, configuration);

            ReceitaFederalService rfService = new(rfClient);
            var loggerCsvParser = Mock.Of<ILogger<CsvParserService>>();
            CsvParserService cnaeParser = new(loggerCsvParser);
            var loggerCnaeManager = Mock.Of<ILogger<CnaeManager>>();
            var mockSet = new Mock<DbSet<Cnae>>();

            CnaeManager cnaeManager = new(_dbContext, cnaeParser, rfService, loggerCnaeManager);
            await cnaeManager.ImportData();
            var cnae = await _dbContext.Cnae.FirstOrDefaultAsync(c => c.Code == "0111301");
            cnae!.Code.Should().Be("0111301");
            Console.WriteLine("cnae");
            Console.WriteLine(cnae);

            //cnae!.Code.Should().Be("0111301");
        }
    }
}