using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models;

namespace Firma.Services
{
    public interface IReceitaFederalService
    {
        //Task<string> DataDownload(IEnumerable<string> links, string destinationDirectory);
        Task<string> Download(DownloadTarget target);
        Task<string> TaxRegimeDownload(DownloadTarget target);
        public void DeleteFiles(string pathDirectory);
    }
}