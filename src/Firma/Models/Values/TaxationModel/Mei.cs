using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.TaxationModel
{
    public class Mei
    {
        public int Id { get; set; }
        public bool Opting { get; set; }
        public DateOnly? InclusionDate { get; set; }
        public DateOnly? ExclusionDate { get; set; }
    }
}