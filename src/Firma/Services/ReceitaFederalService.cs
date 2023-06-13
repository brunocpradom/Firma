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

        public async Task<string> DataDownload(IEnumerable<string> links)
        {
            var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(),"temp");
            
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
            var cnaeLinks = await _rfClient.GetCnaesLinks();
            var destinationDirectory = await DataDownload(cnaeLinks);
            return  destinationDirectory;
        }

        public async Task<string> CompanyDataDownload()
        {
            var empresasLinks = await _rfClient.GetCompanyLinks();
            var destinationDirectory = await DataDownload(empresasLinks);
            return  destinationDirectory;
        }

        public async Task<string> EstablishmentDataDownload()
        {
            var estabelecimentosLinks = await _rfClient.GetEstablishmentsLinks();
            var destinationDirectory = await DataDownload(estabelecimentosLinks);
            return  destinationDirectory;
        }

        public async Task<string> MotivesDataDownload()
        {
            var motivosLinks = await _rfClient.GetMotivesLinks();
            var destinationDirectory = await DataDownload(motivosLinks);
            return  destinationDirectory;
        }

        public async Task<string> CityDataDownload()
        {
            var municipiosLinks = await _rfClient.GetCityLinks();
            var destinationDirectory = await DataDownload(municipiosLinks);
            return  destinationDirectory;
        }

        public async Task<string> LegalNatureDownload()
        {
            var naturezaJuridicaLinks = await _rfClient.GetLegalNatureLinks();
            var destinationDirectory = await DataDownload(naturezaJuridicaLinks);
            return  destinationDirectory;
        }

        public async Task<string> CountryDataDownload()
        {
            var paisesLinks = await _rfClient.GetCountriesLinks();
            var destinationDirectory = await DataDownload(paisesLinks);
            return  destinationDirectory;
        }

        public async Task<string> QualificationsDataDownload()
        {
            var qualificacoesLinks = await _rfClient.GetQualificationsLinks();
            var destinationDirectory = await DataDownload(qualificacoesLinks);
            return  destinationDirectory;
        }

        public async Task<string> TaxRegimeDownload()
        {
            var regimeTributariosLinks = await _rfClient.GetTaxRegimeLinks();
            var destinationDirectory = await DataDownload(regimeTributariosLinks);
            return  destinationDirectory;
        }

        public async Task<string> SimplesDataDownload()
        {
            var simplesLinks = await _rfClient.GetSimplesLink();
            var destinationDirectory = await DataDownload(simplesLinks);
            return  destinationDirectory;
        }

        public async Task<string> PartnerDataDownload()
        {
            var sociosLinks = await _rfClient.GetPartnerLinks();
            var destinationDirectory = await DataDownload(sociosLinks);
            return  destinationDirectory;
        }
    }
}

