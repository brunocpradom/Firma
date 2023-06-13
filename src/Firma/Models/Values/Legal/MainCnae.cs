using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Models.Values.Legal
{
    public class MainCnae
    {
        public int Id { get; set; }
        public required Cnae Cnae { get; set; }
    }
}