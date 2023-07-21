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
    public class CityManager : IManager
    {
        private AppDbContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<CityManager> _logger;

        public ManagerName Name => ManagerName.City;

        public CityManager(AppDbContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<CityManager> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task Update(CityCsvDto record)
        {
            throw new NotImplementedException();
        }

        private async Task Create(CityCsvDto record)
        {
            _logger.LogInformation("Creating City");
            City city = new()
            {
                Code = record.Code,
                Name = record.Description
            };
            _context.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Municipio);
            foreach (var record in _csvParser.ProcessCsv<CityCsvDto>(destinationDirectory))
            {
                var city = await _context.City.FirstOrDefaultAsync(c => c.Code == record.Code);
                if (city is null)
                    await Create(record);
                else
                    await Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}