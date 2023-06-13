using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Legal
{
    public class CadastralSituation
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required CadastralSituationCode Situation { get; set; } 
        public DateOnly CadastralSituationDate { get; set; }
        public required string CadastralSituationReason { get; set; }
        public string SpecialSituation { get; set; } = String.Empty;
        public DateOnly SpecialSituationDate { get; set; }
    }
}
