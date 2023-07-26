using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Dtos.Api
{
    public class LucroDto
    {
        public int Year { get; set; }
        public string ScpTaxId { get; set; } = String.Empty;
        public string FormOfTaxation { get; set; } = String.Empty;
        public int AmountOfBookKeeping { get; set; }
    }
}