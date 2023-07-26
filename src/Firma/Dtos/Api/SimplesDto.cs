using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Dtos.Api
{
    public class SimplesDto
    {
        public bool Opting { get; set; }
        public DateOnly? InclusionDate { get; set; }
        public DateOnly? ExclusionDate { get; set; }
    }
}