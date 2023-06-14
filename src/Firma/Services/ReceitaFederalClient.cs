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