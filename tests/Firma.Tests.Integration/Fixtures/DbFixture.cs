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
            dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();
            return dbContext;
        }

        public DataContext _dbContext => CreateDbContext();

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

    }
}