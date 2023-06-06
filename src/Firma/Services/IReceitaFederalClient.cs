using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Services
{
    public interface IReceitaFederalClient
    {
        Task<IEnumerable<string>> GetLinks(string url);
        Task<IEnumerable<string>> GetMainLinks();
        Task<IEnumerable<string>> GetTaxRegimeLinks();
        Task<IEnumerable<string>> GetCompanyLinks();
        Task<IEnumerable<string>> GetEstablishmentsLinks();
        Task<IEnumerable<string>> GetPartnerLinks();
        Task<IEnumerable<string>> GetCnaesLinks();
        Task<IEnumerable<string>> GetCityLinks();
        Task<IEnumerable<string>> GetLegalNatureLinks();
        Task<IEnumerable<string>> GetCountriesLinks();
        Task<IEnumerable<string>> GetQualificationsLinks();
        Task<IEnumerable<string>> GetSimplesLink();
        Task<IEnumerable<string>> GetMotivesLinks();
        Task<string> DownloadFile(string link, string destinationDirectory);

    }
}