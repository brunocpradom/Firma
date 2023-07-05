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

        public EmpresaController(IReceitaFederalService rfService, ICsvParserService csvParser, ILogger<EmpresaController> logger)
        {
            _rfService = rfService;
            _csvParser = csvParser;
            _logger = logger;
        }

        [HttpGet("teste")]
        public async Task<string> Get()
        {
            await _rfService.TaxRegimeDownload(DownloadTarget.Natureza);
            _logger.LogInformation("teste 123");
            return "ok";
        }

        [HttpGet("csv")]
        public string Csv()
        {

            return "ok";
        }
    }
}