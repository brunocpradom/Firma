using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contatos
{
    public class Email
    {
        public int Id { get; set; }
        public required string Endereço { get; set; }
    }
}