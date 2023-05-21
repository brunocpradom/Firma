using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.ModeloDeTributacao
{
    public class Mei
    {
        public int Id { get; set; }
        public bool Optante { get; set; }
        public DateOnly DataOpcaoPeloMei { get; set; }
        public DateOnly DataExclusaoMei { get; set; }
    }
}