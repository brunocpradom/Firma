using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Companies
{
    public class CadastralSituationReason
    {
        public int Id { get; set; }
        public required  string  Code{ get; set; }
        public required string Description { get; set; }
    }
}