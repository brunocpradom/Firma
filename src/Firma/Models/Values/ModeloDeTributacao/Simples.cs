using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.ModeloDeTributacao
{
    public class Simples
    {
        public int Id { get; set; }
        public bool Optante { get; set; }
        public DateOnly DataOpcaoPeloSimples { get; set; }
        public DateOnly DataExclusaoSimples { get; set; }
    }
}