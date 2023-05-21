using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Models.Values.Empresas;
using Firma.Models.Values.Legal;
using Firma.Models.Values.ModeloDeTributacao;

namespace Firma.Models.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public required string CnpjBasico { get; set; }
        public required string RazaoSocial { get; set; }
        public required NaturezaJuridica NaturezaJuridica { get; set; }
        public int CapitalSocial { get; set; }
        public required Porte Porte { get; set; }
        public required RegimeTributario RegimeTributario { get; set; }
        public string? EnteFederativoResponsavel { get; set; }
        public QualificacaoResponsavel? QualificacaoDoResponsavel { get; set; }


    }
}