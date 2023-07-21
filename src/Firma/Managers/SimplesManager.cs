using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Entities;
using Firma.Models.Values.TaxationModel;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public class SimplesManager : IManager
    {
        public Company? company { get; set; }
        private AppDbContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<SimplesManager> _logger;

        public ManagerName Name => ManagerName.Simples;

        public SimplesManager(AppDbContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<SimplesManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task Update(SimplesCsvDto record)
        {
            throw new NotImplementedException();
        }
        private DateOnly? parseDate(string date)
        {
            if (int.Parse(date) == 0)
                return null;
            return DateOnly.ParseExact(date, "yyyyMMdd");
        }
        private Simples CreateSimples(SimplesCsvDto record)
        {
            _logger.LogInformation("Creating Simples");

            Simples simples = new()
            {
                Opting = record.OptionForSimple == "S" ? true : false, // aqui tem opção em branco q significa outros
                InclusionDate = parseDate(record.OptionForSimpleInclusionDate!),
                ExclusionDate = parseDate(record.OptionForSimpleExclusionDate!),
            };
            return simples;
        }

        private Mei CreateMei(SimplesCsvDto record)
        {
            Mei mei = new()
            {
                Opting = record.OptionForSimple == "S" ? true : false, // aqui tem opção em branco q significa outros
                InclusionDate = parseDate(record.OptionForMeiInclusionDate!),
                ExclusionDate = parseDate(record.OptionForMeiExclusionDate!),
            };
            return mei;
        }

        private async Task Create(SimplesCsvDto record)
        {
            Simples? simples = null;
            Mei? mei = null;
            if (company!.TaxRegime.Simples is null)
            {
                simples = CreateSimples(record);
            }
            if (company.TaxRegime.Mei is null)
            {
                mei = CreateMei(record);
            }
            company.TaxRegime.Simples = simples;
            company.TaxRegime.Mei = mei;
            await _context.SaveChangesAsync();
        }

        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Simples);
            foreach (var record in _csvParser.ProcessCsv<SimplesCsvDto>(destinationDirectory))
            {
                company = await _context.Company
                    .Include(c => c.TaxRegime)
                    .FirstAsync(c => c.BasicTaxId == record.BasicTaxId);

                if (company.TaxRegime.Simples is null)
                    await Create(record);
                else
                    await Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}