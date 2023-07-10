using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace Firma.Tests.Integration.Fixtures
{

    public class ServicesFixture
    {
        public string projectPath => Path.GetFullPath("../../../", Directory.GetCurrentDirectory());

        public HttpClient httpClient = new();

        public IConfiguration mockConfiguration => new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(projectPath, "appsettings.Development.json"))
                .Build();

        public ReceitaFederalClient receitaFederalClientMock()
        {
            var loggerRfClient = Mock.Of<ILogger<ReceitaFederalClient>>();
            ReceitaFederalClient rfClient = new(loggerRfClient, httpClient, mockConfiguration);
            return rfClient;
        }
    }
}