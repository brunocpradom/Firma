using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;

namespace Firma.Models.Values.TaxationModel
{
    public class TaxRegime
    {
        public int Id { get; set; }
        public required Company Company { get; set; }
        public Mei? Mei { get; set; }
        public Simples? Simples { get; set; }
        public Lucro? Lucro { get; set; }

    }
}