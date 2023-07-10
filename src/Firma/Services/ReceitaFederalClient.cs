using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;


namespace Firma.Services
{
    public class ReceitaFederalClient : IReceitaFederalClient
    {
        private string _baseUrl;
        private ILogger<ReceitaFederalClient> _logger;
        private HttpClient _client;
        private IConfiguration _configuration;

        public ReceitaFederalClient(ILogger<ReceitaFederalClient> logger, HttpClient client, IConfiguration configuration)
        {
            _logger = logger;
            _client = client;
            _configuration = configuration;
            _baseUrl = _configuration.GetSection("ReceitaFederalUrl").Value!;
        }

        private async Task<IEnumerable<string>> GetLinks(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            string htmlContent = await response.Content.ReadAsStringAsync();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlContent);

            var links = htmlDoc.DocumentNode.Descendants("a")
                .Select(a => a.GetAttributeValue("href", null))
                .Where(href => !string.IsNullOrEmpty(href))
                .Where(l => l.EndsWith(".zip"))
                .Select(t => $"{_baseUrl}/CNPJ/{t}");
            return links;
        }


        public virtual async Task<IEnumerable<string>> GetMainLinks()
        {
            return await GetLinks($"{_baseUrl}/CNPJ/");
        }

        public async Task<IEnumerable<string>> GetTaxRegimeLinks()
        {
            return await GetLinks($"{_baseUrl}/CNPJ/regime_tributario/");
        }

        public virtual async Task<string> DownloadFile(string link, string destinationDirectory)
        {
            _logger.LogInformation("Download start!");
            _logger.LogInformation($"DestinationDirectory : {destinationDirectory}");

            var fileName = link.Split("/").Last();
            var destinationPath = Path.Combine(destinationDirectory, fileName);

            var response = await _client.GetStreamAsync(link);
            await using var fileStream = new FileStream(destinationPath, FileMode.OpenOrCreate);
            await response.CopyToAsync(fileStream);
            await fileStream.FlushAsync();

            _logger.LogInformation("Download finished");

            return destinationPath;

        }
    }
}