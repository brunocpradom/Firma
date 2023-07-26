using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Firma.Data;
using Firma.Dtos.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.Controllers
{
    [ApiController]
    [Route("company")]
    public class CompanyController
    {
        private ILogger<CompanyController> _logger;
        private AppDbContext _context;
        private IMapper _mapper;

        public CompanyController(ILogger<CompanyController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("/company")]
        public async Task<List<CompanyDto>> Get()
        {
            var companies = await _context.Company.ToListAsync();
            return _mapper.Map<CompanyDto[]>(companies).ToList();
        }

        [HttpGet("/company/{cnpj}")]
        public async Task<CompanyDto> Get(string cnpj)
        {
            var company = await _context.Company.FirstOrDefaultAsync(c => c.BasicTaxId == cnpj.Substring(0, 8));
            return _mapper.Map<CompanyDto>(company);
        }
    }
}