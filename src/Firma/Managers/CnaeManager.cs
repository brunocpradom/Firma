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
    public class CnaeManager
    {
        private DataContext _context;
        private ICsvParserService _cnaeCsvParser;
        private IReceitaFederalService _receitaFederal;
        private readonly ILogger<CnaeManager> _logger;

        public CnaeManager(DataContext context, ICsvParserService cnaeCsvParser, IReceitaFederalService receitaFederal, ILogger<CnaeManager> logger)
        {
            _context = context;
            _cnaeCsvParser = cnaeCsvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        public async void ImportData()
        {
            _logger.LogInformation("Creating Cnae");
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Cnae);
            foreach(var record in _cnaeCsvParser.ProcessCsv<CnaeCsvDto>(destinationDirectory))
            {
                var cnae = await _context.Cnae.FirstOrDefaultAsync(c=> c.Code == record.Code);
                if(cnae is null)
                {
                    _context.Cnae.Add(
                        new Cnae(){Code = record.Code, Description = record.Description}
                        );
                    await _context.SaveChangesAsync();
                }
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}