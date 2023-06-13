using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Dtos.Csv
{
    public class LegalNatureCsvDto
    {
        public required string Code { get; set; }
        public required string Description { get; set; }
    }
}