using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;

namespace Firma.Models.Values.ModeloDeTributacao
{
    public class RegimeTributario
    {
        public int Id { get; set; }
        public required Empresa Empresa { get; set; }
        public Mei? Mei { get; set; }
        public Simples? Simples { get; set; }
        public Lucro? Lucro { get; set; }

    }
}