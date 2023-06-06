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
        public required string Situation { get; set; } // Acho que só o codigo basta. ou um ENum
        public DateOnly CadastralSituationDate { get; set; }
        public required string CadastralSituationReason { get; set; }
        public string SpecialSituation { get; set; } = String.Empty;
        public DateOnly SpecialSituationDate { get; set; }
    }
}

// CÓDIGO DA SITUAÇÃO CADASTRAL:
// 01 – NULA
// 2 – ATIVA
// 3 – SUSPENSA
// 4 – INAPTA
// 08 – BAIXADA