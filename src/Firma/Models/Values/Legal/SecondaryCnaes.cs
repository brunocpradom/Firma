using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Legal
{
    public class SecondaryCnaes
    {
        public int Id { get; set; }
        public required List<Cnae> Cnaes { get; set; }
    }
}