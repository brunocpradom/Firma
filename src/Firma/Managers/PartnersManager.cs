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
    public class PartnersManager : IManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<PartnersManager> _logger;

        public ManagerName Name => ManagerName.Partner;

        public PartnersManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<PartnersManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task Create(PartnerCsvDto record)
        {
            _logger.LogInformation("Creating Partner.");
            var company = await _context.Company.FirstAsync(c => c.BasicTaxId == record.BasicTaxId);
            var qualification = await _context.Qualification.FirstAsync(q => q.Code == record.Qualification);
            var countryCode = string.IsNullOrWhiteSpace(record.Country) ? "105" : record.Country;
            var country = await _context.Country.FirstAsync(c => c.Code == countryCode);
            var representativeQualification = await _context.Qualification.FirstAsync(q => q.Code == record.RepresentativeQualification);
            Partner partner = new()
            {
                Company = company,
                Identifier = (PartnerIdentifier)Enum.ToObject(typeof(PartnerIdentifier), int.Parse(record.Identifier)),
                Name = record.Name,
                DocumentNumber = record.DocumentNumber,
                Qualification = qualification,
                AgeGroup = (AgeGroup)Enum.ToObject(typeof(AgeGroup), int.Parse(record.AgeGroup)),
                CompanyJoiningDate = DateOnly.ParseExact(record.CompanyJoiningDate, "yyyyMMdd"),
                Country = country,
                LegalRepresentative = record.LegalRepresentative,
                RepresentativeName = record.RepresentativeName,
                RepresentativeQualification = representativeQualification
            };
            _context.Add(partner);
            await _context.SaveChangesAsync();
        }

        private async Task Update(PartnerCsvDto record)
        {
            throw new NotImplementedException();
        }

        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Socio);
            foreach (var record in _csvParser.ProcessCsv<PartnerCsvDto>(destinationDirectory))
            {
                var partner = await _context.Partner.FirstOrDefaultAsync(p => p.Name == record.Name);
                if (partner is null)
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