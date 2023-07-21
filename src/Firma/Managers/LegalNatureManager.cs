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
    public class LegalNatureManager : IManager
    {
        private AppDbContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<LegalNatureManager> _logger;

        public ManagerName Name => ManagerName.LegalNature;

        public LegalNatureManager(AppDbContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<LegalNatureManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task Update(LegalNatureCsvDto record)
        {
            throw new NotImplementedException();
        }

        private async Task Create(LegalNatureCsvDto record)
        {
            _logger.LogInformation("Creating Legal Nature.");
            LegalNature legalNature = new()
            {
                Code = record.Code,
                Description = record.Description
            };
            _context.Add(legalNature);
            await _context.SaveChangesAsync();
        }

        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Natureza);
            foreach (var record in _csvParser.ProcessCsv<LegalNatureCsvDto>(destinationDirectory))
            {
                var country = await _context.LegalNature.FirstOrDefaultAsync(l => l.Code == record.Code);
                if (country is null)
                    await Create(record);
                else
                    await Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}