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
        private readonly ICnaeManager _cnaeManager;

        public EmpresaController(IReceitaFederalService rfService, ICsvParserService csvParser, ILogger<EmpresaController> logger, ICnaeManager cnaeManager)
        {
            _rfService = rfService;
            _csvParser = csvParser;
            _logger = logger;
            _cnaeManager = cnaeManager;
        }

        [HttpGet("teste")]
        public async Task<string> Get()
        {
            await _rfService.Download(DownloadTarget.Cnae);
            _logger.LogInformation("teste 123");
            return "ok";
        }

        [HttpGet("csv")]
        public async Task<string> Csv()
        {
            await _cnaeManager.ImportData();
            return "ok";
        }
    }
}