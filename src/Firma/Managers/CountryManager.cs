using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Values.Contact;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public class CountryManager : IManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<CountryManager> _logger;

        public ManagerName Name => ManagerName.Country;

        public CountryManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<CountryManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task Update(CountryCsvDto record)
        {
            throw new NotImplementedException();
        }

        private async Task Create(CountryCsvDto record)
        {
            _logger.LogInformation("Creating Country");
            Country country = new()
            {
                Code = record.Code,
                Name = record.Description
            };
            _context.Add(country);

        }

        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Pais);
            foreach (var record in _csvParser.ProcessCsv<CountryCsvDto>(destinationDirectory))
            {
                if (!await _context.Country.AnyAsync(c => c.Code == record.Code))
                    await Create(record);
                else
                    await Update(record);
            }
            await _context.SaveChangesAsync();
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}