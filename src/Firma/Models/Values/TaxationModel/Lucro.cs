using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.TaxationModel
{
    public class Lucro
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string ScpTaxId { get; set; } = String.Empty;
        public string FormOfTaxation { get; set; } = String.Empty;
        public int AmountOfBookKeeping { get; set; }
    }
}