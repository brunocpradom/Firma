using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data;
using Firma.Dtos.Csv;
using Firma.Models;
using Firma.Models.Entities;
using Firma.Models.Values.Companies;
using Firma.Models.Values.Contact;
using Firma.Models.Values.Legal;
using Firma.Services;
using Microsoft.EntityFrameworkCore;

namespace Firma.Managers
{
    public class EstablishmentsManager : IManager
    {
        private DataContext _context;
        private ICsvParserService _csvParser;
        private IReceitaFederalService _receitaFederal;
        private ILogger<ReceitaFederalClient> _logger;

        public ManagerName Name => ManagerName.Establishment;

        public EstablishmentsManager(DataContext context, ICsvParserService csvParser, IReceitaFederalService receitaFederal, ILogger<ReceitaFederalClient> logger)
        {
            _context = context;
            _csvParser = csvParser;
            _receitaFederal = receitaFederal;
            _logger = logger;
        }

        private async Task Update(EstablishmentCsvDto record)
        {
            throw new NotImplementedException();
        }
        private async Task<CadastralSituation> CreateCadastralSituation(EstablishmentCsvDto record)
        {
            CadastralSituationReason reason = await _context.CadastralSituationReason.FirstAsync(r => r.Code == record.CadastralSituationReason);
            CadastralSituation cadastralSituation = new()
            {
                Situation = (CadastralSituationCode)Enum.ToObject(typeof(CadastralSituationCode), record.CadastralSituation),
                CadastralSituationDate = record.CadastralSituationDate,
                CadastralSituationReason = reason,
                SpecialSituation = record.SpecialSituation,
                SpecialSituationDate = record.SpecialSituationDate,
            };
            return cadastralSituation;
        }

        private async Task<Address> CreateAddress(EstablishmentCsvDto record)
        {
            var city = await _context.City.FirstAsync(c => c.Code == record.City);
            var country = await _context.Country.FirstAsync(c => c.Code == record.Country);
            Address address = new()
            {
                ForeignCityName = record.ForeignCityName,
                Country = country,
                StreetType = record.StreetType,
                StreetAddress = record.StreetAddress,
                Number = record.Number,
                Complement = record.Complement,
                Neighborhood = record.Neighborhood,
                ZipCode = record.ZipCode,
                State = record.State,
                City = city,
            };
            return address;
        }

        private async Task<SecondaryCnaes?> CreateSecondaryCnaes(EstablishmentCsvDto record)
        {
            SecondaryCnaes? secondaryCnae = null;
            if (record.SecondaryCnae is not null)
            {
                var splitSecondaryCnaes = record.SecondaryCnae.Split(",");
                var secondaryCnaes = await _context.Cnae.Where(c => splitSecondaryCnaes.Contains(c.Code))
                         .ToListAsync();
                secondaryCnae = new() { Cnaes = secondaryCnaes };
            }
            return secondaryCnae;
        }

        private async Task<MainCnae> CreateMainCnae(EstablishmentCsvDto record)
        {
            var cnae = await _context.Cnae.FirstAsync(cn => cn.Code == record.MainCnae);
            MainCnae mainCnae = new() { Cnae = cnae };
            return mainCnae;
        }

        private List<Telephone> CreateTelephones(EstablishmentCsvDto record)
        {
            var telephones = new List<Telephone>
            {
                new Telephone {DDD = record.DDD1, Number = record.Telephone1},
                new Telephone {DDD = record.DDD2, Number = record.Telephone2}
            };
            return telephones;
        }

        private async Task Create(EstablishmentCsvDto record)
        {
            _logger.LogInformation("Creating Establishment.");
            MainCnae mainCnae = await CreateMainCnae(record);
            SecondaryCnaes? secondaryCnae = await CreateSecondaryCnaes(record);
            CadastralSituation cadastralSituation = await CreateCadastralSituation(record);
            Address address = await CreateAddress(record);
            List<Telephone> telephones = CreateTelephones(record);
            List<Email> emails = new() { new Email { Address = record.Email } };

            var company = await _context.Company.FirstAsync(c => c.BasicTaxId == record.BasicTaxId);
            var establishment = new Establishment()
            {
                Company = company,
                TaxId = $"{record.BasicTaxId}{record.OrderTaxId}{record.DVTaxId}",
                Identifier = (Identifier)Enum.ToObject(typeof(Identifier), record.Identifier),
                TradeName = record.TradeName,
                ActivityStartDate = record.ActivityStartDate,
                CadastralSituation = cadastralSituation,
                MainCnae = mainCnae,
                SecondaryCnaes = record.SecondaryCnae is not null ? secondaryCnae : null,
                Address = address,
                Telephone = telephones,
                Email = emails
            };

            _context.Add(establishment);
            await _context.SaveChangesAsync();
        }

        public async Task ImportData()
        {
            var destinationDirectory = await _receitaFederal.Download(DownloadTarget.Estabelecimento);
            foreach (var record in _csvParser.ProcessCsv<EstablishmentCsvDto>(destinationDirectory))
            {
                var taxId = $"{record.BasicTaxId}{record.OrderTaxId}{record.DVTaxId}";
                var establishment = await _context.Establishment.FirstOrDefaultAsync(e => e.TaxId == taxId);

                if (establishment is null)
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