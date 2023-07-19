using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Entities;
using Firma.Models.Values.Companies;

namespace Firma.Models.Values.Legal
{
    public class CadastralSituation
    {
        public int Id { get; set; }
        public Establishment? Establishment { get; set; }
        public int EstablishmentId { get; set; }
        public required CadastralSituationCode Situation { get; set; }
        public DateOnly? CadastralSituationDate { get; set; }
        public required CadastralSituationReason CadastralSituationReason { get; set; }
        public string SpecialSituation { get; set; } = String.Empty;
        public DateOnly? SpecialSituationDate { get; set; }
    }
}
