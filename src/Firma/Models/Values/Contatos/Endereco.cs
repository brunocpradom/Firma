using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Contatos
{
    public class Endereco
    {
        public int Id { get; set; }
        public string NomeDaCidadeNoExterior { get; set; } = String.Empty;
        public string Pais { get; set; } = String.Empty;
        public string TipoLogradouro { get; set; } = String.Empty;
        public string Logradouro { get; set; } = String.Empty;
        public string Numero { get; set; } = String.Empty;
        public string Complemento { get; set; } = String.Empty;
        public string Bairro { get; set; } = String.Empty;
        public string Cep { get; set; } = String.Empty;
        public string UF { get; set; } = String.Empty;
        public string Municipio { get; set; } = String.Empty;
    }
}