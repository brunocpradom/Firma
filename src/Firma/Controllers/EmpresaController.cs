using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Managers;
using Firma.Models;
using Firma.Services;
using Microsoft.AspNetCore.Mvc;

namespace Firma.Controllers
{
    [ApiController]
    [Route("empresa")]
    public class EmpresaController
    {
        private IReceitaFederalService _rfService;
        private ICsvParserService _csvParser;
        private readonly ILogger<EmpresaController> _logger;
        private readonly IEnumerable<IManager> _managers;

        public EmpresaController(IReceitaFederalService rfService, ICsvParserService csvParser, ILogger<EmpresaController> logger, IEnumerable<IManager> managers)
        {
            _rfService = rfService;
            _csvParser = csvParser;
            _logger = logger;
            _managers = managers;
        }

        [HttpGet("teste")]
        public async Task<string> Get()
        {
            await _rfService.Download(DownloadTarget.Cnae);
            _logger.LogInformation("teste 123");
            return "ok";
        }

        [HttpGet("cnae")]
        public async Task<string> Cnae()
        {
            var cnaeManager = _managers.Single(m => m.Name == ManagerName.Cnae);
            await cnaeManager.ImportData();
            return "ok";
        }

        [HttpGet("city")]
        public async Task<string> City()
        {
            var cityManager = _managers.Single(m => m.Name == ManagerName.City);
            await cityManager.ImportData();
            return "ok";
        }
    }
}