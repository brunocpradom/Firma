using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contact
{
    public class Adress
    {
        public int Id { get; set; }
        public string ForeignCityName { get; set; } = String.Empty;
        public string Country { get; set; } = String.Empty;
        public string StreetType { get; set; } = String.Empty;
        public string StreetAddress { get; set; } = String.Empty;
        public string Number { get; set; } = String.Empty;
        public string Complement { get; set; } = String.Empty;
        public string Neighborhood { get; set; } = String.Empty;
        public string ZipCode { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
    }
}