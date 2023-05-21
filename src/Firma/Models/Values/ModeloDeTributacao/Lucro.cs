using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.ModeloDeTributacao
{
    public class Lucro
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public string CnpjDaScp { get; set; } = String.Empty;
        public string FormaDeTributacao { get; set; } = String.Empty;
        public int QuantidadeDeEscrituracoes { get; set; }
    }
}