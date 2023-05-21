using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Values.Contatos;
using Firma.Models.Values.Empresas;
using Firma.Models.Values.Legal;

namespace Firma.Models.Entities
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public required Empresa Empresa { get; set; }
        public required string Cnpj { get; set; }
        public required Identificador Identificador { get; set; }
        public string? NomeFantasia { get; set; }
        public DateOnly DataInicioAtividade { get; set; }
        public required SituacaoCadastral SituacaoCadastral { get; set; }
        public required Cnae CnaeFiscalPrincipal { get; set; }
        public List<Cnae>? CnaeFiscalSecundaria { get; set; } //manytomany
        public required Endereco Endereco { get; set; }
        public List<Telefone>? Telefone { get; set; }
        public List<Email>? Email { get; set; }

    }
}