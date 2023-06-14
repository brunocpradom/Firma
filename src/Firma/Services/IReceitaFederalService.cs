using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Services
{
    public interface IReceitaFederalService
    {
        Task<string> DataDownload(IEnumerable<string> links, string destinationDirectory);
        Task<string> EstablishmentDataDownload(); 
        Task<string> CompanyDataDownload();
        Task<string> PartnerDataDownload();
        Task<string> CnaesDataDownload();
        Task<string> TaxRegimeDownload();
        Task<string> LegalNatureDownload();
        Task<string> SimplesDataDownload();
        Task<string> QualificationsDataDownload();
        Task<string> CountryDataDownload();
        Task<string> CityDataDownload();
        Task<string> MotivesDataDownload();
    }
}