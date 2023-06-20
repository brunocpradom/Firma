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
    public class CadastralSituationReasonManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<ReceitaFederalClient> _logger;

        public CadastralSituationReasonManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<ReceitaFederalClient> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async void Update(CadastralSituationReasonDto record)
        {
        }

        private async void Create(CadastralSituationReasonDto record)
        {
            _logger.LogInformation("Creating Cadastral Situation Reason");
            CadastralSituationReason cadastralSituationReason = new(){
                Code = record.Code,
                Description = record.Description
            };
            _context.Add(cadastralSituationReason);
            await _context.SaveChangesAsync();
        }

        public async void ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Motivo);
            foreach(var record in _csvParser.ProcessCsv<CadastralSituationReasonDto>(destinationDirectory))
            {
                var country = await _context.CadastralSituationReason.FirstOrDefaultAsync(c=> c.Code == record.Code);
                if(country is null)
                    Create(record);
                else
                    Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}