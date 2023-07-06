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

            DataContext dataContext = new(optionsBuilder.Options);
            dataContext.Database.Migrate();
            return dataContext;
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