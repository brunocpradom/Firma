using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Values.Partner;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public class QualificationManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<ReceitaFederalClient> _logger;

        public QualificationManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<ReceitaFederalClient> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async void Update(QualificationCsvDto record)
        {
        }

        private async void Create(QualificationCsvDto record)
        {
            _logger.LogInformation("Creating Qualification.");
            Qualification qualification = new(){
                Code = record.Code,
                Description = record.Description
            };
            _context.Add(qualification);
            await _context.SaveChangesAsync();
        }

        public async void ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Qualifica);
            foreach(var record in _csvParser.ProcessCsv<QualificationCsvDto>(destinationDirectory))
            {
                var qualification = await _context.Qualification.FirstOrDefaultAsync(c=> c.Code == record.Code);
                if(qualification is null)
                    Create(record);
                else
                    Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}