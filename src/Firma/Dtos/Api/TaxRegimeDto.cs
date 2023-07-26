using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.Values.TaxationModel;

namespace Firma.Dtos.Api
{
    public class TaxRegimeDto
    {
        public Company? Company { get; set; }
        public int CompanyId { get; set; }
        public Mei? Mei { get; set; }
        public Simples? Simples { get; set; }
        public Lucro? Lucro { get; set; }
    }
}