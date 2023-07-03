using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Dtos.Csv;

namespace Firma.Managers
{
    public interface IManager
    {
        Task ImportData();
    }
}