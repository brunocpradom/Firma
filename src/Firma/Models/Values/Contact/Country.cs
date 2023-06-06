using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contact
{
    public class Country
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}