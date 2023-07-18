using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Entities;
using Firma.Models.Values.Companies;
using Firma.Models.Values.Legal;
using Firma.Models.Values.TaxationModel;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public class CompanyManager : IManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<CompanyManager> _logger;

        public ManagerName Name => ManagerName.Company;

        public CompanyManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<CompanyManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task Update(CompanyCsvDto record)
        {
            throw new NotImplementedException();
        }
        private async Task Create(CompanyCsvDto record)
        {
            _logger.LogInformation("Creating Company.");
            var legalNature = await _context.LegalNature.FirstOrDefaultAsync(l => l.Code == record.LegalNature);
            var qualificationOfPersonInCharge = await _context.Qualification.FirstOrDefaultAsync(q => q.Code == record.QualificationOfPersonInCharge);
            var company = new Company()
            {
                BasicTaxId = record.BasicTaxId,
                RegisteredName = record.RegisteredName,
                LegalNature = legalNature!,
                ShareCapital = record.ShareCapital,
                CompanySize = (CompanySize)Enum.ToObject(typeof(CompanySize), int.Parse(record.CompanySize!)),
                TaxRegime = new TaxRegime() { },
                ResponsibleFederalEntity = record.ResponsibleFederalEntity,
                QualificationOfPersonInCharge = qualificationOfPersonInCharge,
            };
            _context.Add(company);
            await _context.SaveChangesAsync();
        }
        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Empresa);
            foreach (var record in _csvParser.ProcessCsv<CompanyCsvDto>(destinationDirectory))
            {
                var company = await _context.Company.FirstOrDefaultAsync(c => c.BasicTaxId == record.BasicTaxId);
                if (company is null)
                {
                    await Create(record);
                }
                else
                {
                    await Update(record);
                }
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}