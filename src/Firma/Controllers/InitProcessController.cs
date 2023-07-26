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
    public class InitProcessController : ControllerBase
    {
        private readonly ILogger<InitProcessController> _logger;
        private readonly IEnumerable<IManager> _managers;

        public InitProcessController(ILogger<InitProcessController> logger, IEnumerable<IManager> managers)
        {
            _logger = logger;
            _managers = managers;
        }

        [HttpGet("start-process")]
        public async Task<string> StartProcess()
        {
            var cityManager = _managers.Single(m => m.Name == ManagerName.City);
            await cityManager.ImportData();
            var cadastralSituationReasonManager = _managers.Single(m => m.Name == ManagerName.CadastralSituationReason);
            await cadastralSituationReasonManager.ImportData();
            var cnaeManager = _managers.Single(m => m.Name == ManagerName.Cnae);
            await cnaeManager.ImportData();
            var countryManager = _managers.Single(m => m.Name == ManagerName.Country);
            await countryManager.ImportData();
            var legalNatureManager = _managers.Single(m => m.Name == ManagerName.LegalNature);
            await legalNatureManager.ImportData();
            var qualificationManager = _managers.Single(m => m.Name == ManagerName.Qualification);
            await qualificationManager.ImportData();

            var companyManager = _managers.Single(m => m.Name == ManagerName.Company);
            await companyManager.ImportData();
            var establishmentManager = _managers.Single(m => m.Name == ManagerName.Establishment);
            await establishmentManager.ImportData();
            var partnerManager = _managers.Single(m => m.Name == ManagerName.Partner);
            await partnerManager.ImportData();
            var simpleManager = _managers.Single(m => m.Name == ManagerName.Simples);
            await simpleManager.ImportData();
            var taxRegimeManager = _managers.Single(m => m.Name == ManagerName.TaxRegime);
            await taxRegimeManager.ImportData();
            return "ok";
        }
    }
}