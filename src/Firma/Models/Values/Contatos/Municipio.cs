using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contatos
{
    public class Municipio
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public required string Nome { get; set; }
    }
}