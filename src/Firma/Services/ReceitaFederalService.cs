using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO.Compression;
using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace Firma.Services
{
    public class ReceitaFederalService : IReceitaFederalService
    {
        private IReceitaFederalClient _rfClient;

        public ReceitaFederalService(IReceitaFederalClient rfClient)
        {
            _rfClient = rfClient;
        }

        public async Task<string> DataDownload(IEnumerable<string> links, string destinationDirectory)
        {
            foreach(string link in links)
            {
                var destinationPath = await _rfClient.DownloadFile(link, destinationDirectory);
                ZipFile.ExtractToDirectory(destinationPath, destinationDirectory, Encoding.GetEncoding(28591));
                File.Delete(destinationPath);
            }
            return destinationDirectory;
        }
        public async Task<string> CnaesDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "cnae");
            var links = await _rfClient.GetMainLinks();
            var cnaeLinks = links.Where(l => l.Contains("Cnae"));
            await DataDownload(cnaeLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> CompanyDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "company");
            var links = await _rfClient.GetMainLinks();
            var companyLinks = links.Where(l => l.Contains("Empresa"));
            await DataDownload(companyLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> EstablishmentDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "establishment");
            var links = await _rfClient.GetMainLinks();
            var establishmentsLinks = links.Where(l => l.Contains("Estabelecimento"));
            await DataDownload(establishmentsLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> MotivesDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "others");
            var links = await _rfClient.GetMainLinks();
            var motivesLinks = links.Where(l => l.Contains("Motivo"));
            await DataDownload(motivesLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> CityDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "others");
            var links = await _rfClient.GetMainLinks();
            var cityLinks = links.Where(l => l.Contains("Municipio"));
            await DataDownload(cityLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> LegalNatureDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "legal");
            var links = await _rfClient.GetMainLinks();
            var legalNatureLinks = links.Where(l => l.Contains("Natureza"));
            await DataDownload(legalNatureLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> CountryDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "others");
            var links = await _rfClient.GetMainLinks();
            var countryLinks = links.Where(l => l.Contains("Pais"));
            await DataDownload(countryLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> QualificationsDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "others");
            var links = await _rfClient.GetMainLinks();
            var qualificationsLinks = links.Where(l => l.Contains("Qualifica"));
            await DataDownload(qualificationsLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> TaxRegimeDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "legal");
            var taxRegimeLinks = await _rfClient.GetTaxRegimeLinks();
            await DataDownload(taxRegimeLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> SimplesDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "legal");
            var links = await _rfClient.GetMainLinks();
            var simplesLinks = links.Where(l => l.Contains("Simples"));
            await DataDownload(simplesLinks, destinationDirectory);
            return  destinationDirectory;
        }

        public async Task<string> PartnerDataDownload()
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp", "partner");
            var links = await _rfClient.GetMainLinks();
            var partnerLinks = links.Where(l => l.Contains("Socio"));
            await DataDownload(partnerLinks, destinationDirectory);
            return  destinationDirectory;
        }
    }
}

