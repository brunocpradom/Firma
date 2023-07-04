using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO.Compression;
using Microsoft.VisualBasic.FileIO;
using System.Text;
using Firma.Models;

namespace Firma.Services
{
    public class ReceitaFederalService : IReceitaFederalService
    {
        private IReceitaFederalClient _rfClient;

        public ReceitaFederalService(IReceitaFederalClient rfClient)
        {
            _rfClient = rfClient;
        }

        private async Task<string> DataDownload(IEnumerable<string> links, string destinationDirectory)
        {
            foreach (string link in links)
            {
                var destinationPath = await _rfClient.DownloadFile(link, destinationDirectory);
                ZipFile.ExtractToDirectory(destinationPath, destinationDirectory, Encoding.GetEncoding(28591));
                File.Delete(destinationPath);
            }
            return destinationDirectory;
        }
        public async Task<string> Download(DownloadTarget target)
        {
            var destinationDirectory = Path.Combine(Path.GetTempPath(), target.ToString());
            Directory.CreateDirectory(destinationDirectory);
            var mainLinks = await _rfClient.GetMainLinks();
            var links = mainLinks.Where(l => l.Contains(target.ToString()));
            await DataDownload(links, destinationDirectory);
            return destinationDirectory;
        }
        public async Task<string> TaxRegimeDownload(DownloadTarget target)
        {
            var destinationDirectory = Path.Combine(Path.GetTempPath(), target.ToString());
            var taxRegimeLinks = await _rfClient.GetTaxRegimeLinks();
            await DataDownload(taxRegimeLinks, destinationDirectory);
            return destinationDirectory;
        }
        public void DeleteFiles(string pathDirectory)
        {
            string[] files = Directory.GetFiles(pathDirectory);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
    }
}

