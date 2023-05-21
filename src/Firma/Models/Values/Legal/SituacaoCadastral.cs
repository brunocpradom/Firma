using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Legal
{
    public class SituacaoCadastral
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public required string Situacao { get; set; } // Acho que só o codigo basta. ou um ENum
        public DateOnly DataSituacaoCadastral { get; set; }
        public required string MotivoSituacaoCadastral { get; set; }
        public string SituacaoEspecial { get; set; } = String.Empty;
        public DateOnly DataSituacaoEspecial { get; set; }
    }
}

// CÓDIGO DA SITUAÇÃO CADASTRAL:
// 01 – NULA
// 2 – ATIVA
// 3 – SUSPENSA
// 4 – INAPTA
// 08 – BAIXADA