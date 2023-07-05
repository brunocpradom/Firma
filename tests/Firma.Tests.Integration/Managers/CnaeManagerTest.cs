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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Testcontainers.PostgreSql;

namespace Firma.Tests.Integration.Managers
{
    public class CnaeManagerTest
    {
        public static readonly PostgreSqlConfiguration DbCredentials = new(
            username: "postgres",
            password: "postgres",
            database: "integration_test_db"
        );
        const string DbHostName = "db";
        private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
                .WithImage("postgres:latest")
                .WithHostname(DbHostName)
                .WithDatabase(DbCredentials.Database)
                .WithUsername(DbCredentials.Username)
                .WithPassword(DbCredentials.Password)
                .Build();

        [SetUp]
        public Task InitializeAsync()
        {
            return _postgres.StartAsync();
        }

        [TearDown]
        public Task DisposeAsync()
        {
            return _postgres.DisposeAsync().AsTask();
        }

        [Test]
        public async Task ImportDataTest()
        {
            MockFileProvider mockFileProvider = new();
            ReceitaFederalClientMock rfClientMock = new();
            ReceitaFederalClient rfClient = rfClientMock.MockDownloadFile();
            ReceitaFederalService rfService = new(rfClient);
            var loggerCsvParser = Mock.Of<ILogger<CsvParserService>>();
            CsvParserService cnaeParser = new(loggerCsvParser);
            var loggerCnaeManager = Mock.Of<ILogger<CnaeManager>>();
            var mockSet = new Mock<DbSet<Cnae>>();

            var optionsMock = new Mock<DbContextOptions<DataContext>>();

            var dataContext = new DataContext(optionsMock.Object);


            CnaeManager cnaeManager = new(dataContext, cnaeParser, rfService, loggerCnaeManager);
            await cnaeManager.ImportData();
        }
    }
}