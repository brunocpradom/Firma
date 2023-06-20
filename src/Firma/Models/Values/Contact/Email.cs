using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;

namespace Firma.Models.Values.Contact
{
    public class Email
    {
        public int Id { get; set; }
        public Establishment? Establishment { get; set; }
        public int EstablishmentId { get; set; }
        public required string Address { get; set; }
    }
}