using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Socio
{
    public class FaixaEtaria
    {
        public int Id { get; set; }
        public required string Codigo { get; set; }
        public required string Descricao { get; set; }
    }
}

// - 1 para os intervalos entre 0 a 12 anos;
// - 2 para os intervalos entre 13 a 20 anos;
// - 3 para os intervalos entre 21 a 30 anos;
// - 4 para os intervalos entre 31 a 40 anos;
// - 5 para os intervalos entre 41 a 50 anos;
// - 6 para os intervalos entre 51 a 60 anos;
// - 7 para os intervalos entre 61 a 70 anos;
// - 8 para os intervalos entre 71 a 80 anos; - 9 para maiores de 80 anos.
// - 0 para não se aplica.