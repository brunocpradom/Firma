using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;

namespace Firma.Models.Values.Legal
{
    public class Cnae
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public string Description { get; set; } = String.Empty;
        public List<Establishment>? Estabelecimentos { get; set; }
    }
}