using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Legal
{
    public class NaturezaJuridica
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = String.Empty;
        public string Descricao { get; set; } = String.Empty;
    }
}