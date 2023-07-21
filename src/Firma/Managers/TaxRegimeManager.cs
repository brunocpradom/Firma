using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Services;
using Microsoft.EntityFrameworkCore;
using Firma.Models.Values.TaxationModel;
using Firma.Models.Entities;
using Firma.Models;

namespace Firma.Managers
{
    public class TaxRegimeManager : IManager
    {
        private AppDbContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<TaxRegimeManager> _logger;

        public ManagerName Name => ManagerName.TaxRegime;

        public TaxRegimeManager(AppDbContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<TaxRegimeManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task<Company> GetCompany(LucroCsvDto record)
        {
            var taxId = Regex.Replace(record.TaxId, "[^0-9]", "");
            var basicTaxId = taxId.Substring(0, 8);
            var company = await _context.Company.FirstAsync(c => c.BasicTaxId == basicTaxId);
            return company;
        }

        private async Task Update(LucroCsvDto record)
        {
            throw new NotImplementedException();
        }

        private async Task Create(LucroCsvDto record)
        {
            _logger.LogInformation("Creating Tax Regime.");
            Company company = await GetCompany(record);
            Lucro lucro = new()
            {
                Year = record.Year,
                ScpTaxId = record.ScrTaxId,
                FormOfTaxation = record.FormOfTaxation,
                AmountOfBookKeeping = record.AmountOfBookkeeping
            };
            company.TaxRegime.Lucro = lucro;
            await _context.SaveChangesAsync();
        }



        public async Task ImportData()
        {
            _logger.LogInformation("Importing TaxRegime Data");
            var destinationDirectory = await _receitaFederal.TaxRegimeDownload(DownloadTarget.Natureza);
            foreach (var record in _csvParser.ProcessCsvWithHeaders<LucroCsvDto>(destinationDirectory))
            {
                Company company = await GetCompany(record);
                if (company.TaxRegime.Lucro is null)
                    await Create(record);
                else
                    await Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}