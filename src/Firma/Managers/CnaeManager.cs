using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Values.Legal;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public interface ICnaeManager
    {
        Task ImportData();
    }

    public class CnaeManager : ICnaeManager
    {
        private DataContext _context;
        private ICsvParserService _cnaeCsvParser;
        private IReceitaFederalService _receitaFederal;
        private readonly ILogger<CnaeManager> _logger;

        public CnaeManager(DataContext context, ICsvParserService cnaeCsvParser,
            IReceitaFederalService receitaFederal, ILogger<CnaeManager> logger)
        {
            _context = context;
            _cnaeCsvParser = cnaeCsvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        public async Task ImportData()
        {
            _logger.LogInformation("Creating Cnae");
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Cnae);

            foreach (var record in _cnaeCsvParser.ProcessCsv<CnaeCsvDto>(destinationDirectory))
            {
                if (!await _context.Cnae.AnyAsync(c => c.Code == record.Code))
                {
                    _context.Cnae.Add(new()
                        {
                            Code = record.Code,
                            Description = record.Description,
                        }
                    );
                }
            }

            // so chamar uma vez para todas as alteraçoes
            await _context.SaveChangesAsync();
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}