using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Values.Contatos;
using Firma.Models.Values.Socio;

namespace Firma.Models.Entities
{
    public class Socio
    {
        public int Id { get; set; }
        public required Empresa Empresa { get; set; }
        public required Identificador Identificador { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string NumeroDocumento { get; set; } = String.Empty; // cpf ou cnpj
        public Qualificacao? Qualificacao { get; set; }
        public FaixaEtaria? FaixaEtaria { get; set; }
        public DateOnly DataEntrada { get; set; }
        public Pais? Pais { get; set; }


        public string RepresentanteLegal { get; set; } = String.Empty;
        public string NomeRepresentante { get; set; } = String.Empty;
        public string QualificacaoDoRepresentante { get; set; } = String.Empty;

    }
}