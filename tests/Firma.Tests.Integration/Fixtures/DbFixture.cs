using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace Firma.Tests.Integration.Fixtures
{
    public class DbFixture : ApiFixture
    {
        protected DataContext _dbContext = null!;
        private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .Build();

        private DataContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder
                .UseSnakeCaseNamingConvention()
                .UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=integration_test_db",
                                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            DataContext dbContext = new(optionsBuilder.Options);
            return dbContext;
        }

        [SetUp]
        public async Task InitializeAsync()
        {
            await _postgres.StartAsync();
            _dbContext = CreateDbContext();
            await _dbContext.Database.MigrateAsync();
        }
        [TearDown]
        public Task DisposeAsync()
        {
            _dbContext.Database.EnsureDeleted();
            return _postgres.DisposeAsync().AsTask();
        }

    }
}