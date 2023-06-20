using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Entities;
using Firma.Models.Values.Partner;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public class PartnersManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<ReceitaFederalClient> _logger;

        public PartnersManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<ReceitaFederalClient> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async void Create(PartnerCsvDto record)
        {
            _logger.LogInformation("Creating Partner.");
            var company = await _context.Company.FirstAsync(c=> c.BasicTaxId == record.BasicTaxId);
            var qualification = await _context.Qualification.FirstAsync(q => q.Code == record.Qualification);
            var country = await _context.Country.FirstAsync(c => c.Code == record.Country);
            Partner partner = new(){
                Company = company,
                Identifier = (PartnerIdentifier)Enum.ToObject(typeof(PartnerIdentifier), record.Identifier),
                Name = record.Name,
                DocumentNumber = record.DocumentNumber,
                Qualification = qualification,
                AgeGroup = (AgeGroup)Enum.ToObject(typeof(AgeGroup), record.AgeGroup),
                CompanyJoiningDate = record.CompanyJoiningDate,
                Country = country,
                LegalRepresentative = record.LegalRepresentative,
                RepresentativeName = record.RepresentativeName,
                RepresentativeQualification = record.RepresentativeQualification
            };
            _context.Add(partner);
            await _context.SaveChangesAsync();
        }

        private async void Update(PartnerCsvDto record)
        {
            var company = await _context.Company.FirstOrDefaultAsync(c=> c.BasicTaxId == record.BasicTaxId);
        }

        public async void ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Socio);
            foreach(var record in _csvParser.ProcessCsv<PartnerCsvDto>(destinationDirectory))
            {
                var partner = await _context.Partner.FirstOrDefaultAsync(p => p.Name == record.Name);
                if(partner is null)
                {
                    Create(record);
                }
                else
                {
                    Update(record);
                }
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}