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
    public class CityManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<ReceitaFederalClient> _logger;

        public CityManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<ReceitaFederalClient> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async void Update(CityCsvDto record)
        {
        }

        private async void Create(CityCsvDto record)
        {
            _logger.LogInformation("Creating City");
            City city = new(){
                Code = record.Code,
                Name = record.Description
            };
            _context.Add(city);
            await _context.SaveChangesAsync();
        }

        public async void ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Municipio);
            foreach(var record in _csvParser.ProcessCsv<CityCsvDto>(destinationDirectory))
            {
                var city = await _context.City.FirstOrDefaultAsync(c=> c.Code == record.Code);
                if(city is null)
                    Create(record);
                else
                    Update(record);
            }
            _receitaFederal.DeleteFiles(destinationDirectory);
        }
    }
}