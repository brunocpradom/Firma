using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;


namespace Firma.Services
{
    public class ReceitaFederalClient : IReceitaFederalClient
    {
        private string _baseUrl =  "http://200.152.38.155/CNPJ/";

        public async Task<IEnumerable<string>> GetLinks(string url)
        {
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);
            var links = doc.DocumentNode.Descendants("a")
                .Select(a => a.GetAttributeValue("href", null))
                .Where(href => !string.IsNullOrEmpty(href))
                .Where(l => l.EndsWith(".zip") )
                .Select(t => $"{_baseUrl}{t}");
            return links;
        }

        public async Task<IEnumerable<string>> GetMainLinks()
        {
            return await GetLinks(_baseUrl);
        }

        public async Task<IEnumerable<string>> GetTaxRegimeLinks()
        {
            return await GetLinks($"{_baseUrl}regime_tributario/");
        }

        public async Task<IEnumerable<string>> GetCompanyLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Empresa"));
        }

        public async Task<IEnumerable<string>> GetEstablishmentsLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Estabelecimento"));
        }

        public async Task<IEnumerable<string>> GetPartnerLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Socio"));
        }

        public async Task<IEnumerable<string>> GetCnaesLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Cnae"));
        }

        public async Task<IEnumerable<string>> GetCityLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Municipio"));
        }

        public async Task<IEnumerable<string>> GetLegalNatureLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Natureza"));
        }

        public async Task<IEnumerable<string>> GetCountriesLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Pais"));
        }

        public async Task<IEnumerable<string>> GetQualificationsLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Qualifica"));
        }

        public async Task<IEnumerable<string>> GetSimplesLink()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Empresa"));
        }

        public async Task<IEnumerable<string>> GetMotivesLinks()
        {
            var mainLinks = await GetMainLinks();
            return mainLinks.Where(l => l.Contains("Motivo"));
        }

        public async Task<string> DownloadFile(string link, string destinationDirectory)
        {
            var fileName = link.Split("/").Last();
            var destinationPath = Path.Combine(destinationDirectory,fileName);
            
            var httpClient = new HttpClient();
            var response = await httpClient.GetStreamAsync(link);
            var fileStream = new FileStream(@destinationPath, FileMode.OpenOrCreate);
            await response.CopyToAsync(fileStream);
            fileStream.Dispose();
            return destinationPath;
            
        }
    }
}