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

namespace Firma.Managers
{
    public class TaxRegimeManager : IManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<ReceitaFederalClient> _logger;

        public TaxRegimeManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<ReceitaFederalClient> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task<Company> GetCompany(LucroCsvDto record)
        {
            var taxId = Regex.Replace(record.TaxId, "[^0-9]", "");
            var basicTaxId = taxId.Substring(0,8);
            var company = await _context.Company.FirstAsync(c => c.BasicTaxId == basicTaxId);
            return company;
        }

        private async Task Update(LucroCsvDto record)
        {
        }

        private async Task Create(LucroCsvDto record)
        {
            _logger.LogInformation("Creating Tax Regime.");
            Company company = await GetCompany(record);
            Lucro lucro = new(){
                Year = record.Year,
                ScpTaxId = record.ScrTaxId,
                FormOfTaxation = record.FormOfTaxation,
                AmountOfBookKeeping = record.AmountOfBookkeeping
            };
            company.TaxRegime.Lucro = lucro;
            _context.Add(company);
            await _context.SaveChangesAsync();
        }

        

        public async Task ImportData()
        {
            _logger.LogInformation("Importing TaxRegime Data");
            var destinationDirectory = await _receitaFederal.TaxRegimeDownload();
            foreach(var record in _csvParser.ProcessCsv<LucroCsvDto>(destinationDirectory))
            {
                Company company = await GetCompany(record);
                if(company.TaxRegime.Lucro is null)
                    await Create(record);
                else
                    await Update(record);
            }
        }
    }
}