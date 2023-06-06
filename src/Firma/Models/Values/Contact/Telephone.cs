using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contact
{
    public class Telephone
    {
        public int Id { get; set; }
        public required string DDD { get; set; }
        public required string Number { get; set; }
    }
}