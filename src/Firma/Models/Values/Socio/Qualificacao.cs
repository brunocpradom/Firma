using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Socio
{
    public class Qualificacao
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public required string Descricao { get; set; }
    }
}