using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Firma.Tests.Integration.Fixtures
{
    class ApplicationFactory : WebApplicationFactory<Program>
    {
        readonly Action<IWebHostBuilder> configure;

        public ApplicationFactory(Action<IWebHostBuilder> configure) =>
            this.configure = configure;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var dir = Directory.GetCurrentDirectory();
            builder.UseContentRoot(dir);
            configure(builder);
        }
    }


    public class ServicesFixture
    {
        private protected ApplicationFactory WebApplicationFactory { get; private set; } = null!;
    }
}