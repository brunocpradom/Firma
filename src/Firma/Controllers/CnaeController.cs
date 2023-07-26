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
    [Route("cnae")]
    public class CnaeController
    {
        private ILogger<CnaeController> _logger;
        private AppDbContext _context;
        private IMapper _mapper;

        public CnaeController(ILogger<CnaeController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/cnae")]
        public async Task<List<CnaeDto>> Get()
        {
            var cnaes = await _context.Cnae.ToListAsync();
            return _mapper.Map<CnaeDto[]>(cnaes).ToList();
        }
        [HttpGet("/cnae/{code}")]
        public async Task<CnaeDto> Get(string code)
        {
            var cnae = await _context.Cnae.FirstOrDefaultAsync(c => c.Code == code);
            return _mapper.Map<CnaeDto>(cnae);
        }
    }
}