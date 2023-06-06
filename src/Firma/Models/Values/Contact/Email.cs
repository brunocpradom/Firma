using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contact
{
    public class Email
    {
        public int Id { get; set; }
        public required string Address { get; set; }
    }
}