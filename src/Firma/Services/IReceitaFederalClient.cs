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
        Task<string> DownloadFile(string link, string destinationDirectory);

    }
}