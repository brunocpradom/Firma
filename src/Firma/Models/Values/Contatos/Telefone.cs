using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contatos
{
    public class Telefone
    {
        public int Id { get; set; }
        public required string DDD { get; set; }
        public required string Numero { get; set; }
    }
}