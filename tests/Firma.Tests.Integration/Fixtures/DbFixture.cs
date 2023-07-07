using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace Firma.Tests.Integration.Fixtures
{
    public class DbFixture
    {
        protected DataContext _dbContext = null!;

        private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .Build();

        DataContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder
                .UseSnakeCaseNamingConvention()
                .UseNpgsql(
                    "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=integration_test_db",
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            DataContext dataContext = new(optionsBuilder.Options);
            return dataContext;
        }

        [SetUp]
        public async Task InitializeAsync()
        {
            await _postgres.StartAsync();
            _dbContext = CreateDbContext();
            await _dbContext.Database.MigrateAsync();
        }

        [TearDown]
        public async Task DisposeAsync()
        {
            await _postgres.DisposeAsync();
        }
    }
}