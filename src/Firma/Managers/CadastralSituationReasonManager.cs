using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Values.Companies;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public class CadastralSituationReasonManager : IManager
    {
        private AppDbContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<CadastralSituationReasonManager> _logger;

        public ManagerName Name => ManagerName.CadastralSituationReason;

        public CadastralSituationReasonManager(AppDbContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<CadastralSituationReasonManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private void Update(CadastralSituationReasonDto record)
        {
            throw new NotImplementedException();
        }

        private async Task Create(CadastralSituationReasonDto csvDto)
        {
            _logger.LogInformation("Creating Cadastral Situation Reason");
            CadastralSituationReason cadastralSituationReason = new()
            {
                Code = csvDto.Code,
                Description = csvDto.Description
            };
            _context.Add(cadastralSituationReason);
            await _context.SaveChangesAsync();
        }

        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Motivo);
            foreach (var record in _csvParser.ProcessCsv<CadastralSituationReasonDto>(destinationDirectory))
            {
                var cadastralSituationReason = await _context.CadastralSituationReason.FirstOrDefaultAsync(c => c.Code == record.Code);
                if (cadastralSituationReason is null)
                    await Create(record);
                else
                    Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}