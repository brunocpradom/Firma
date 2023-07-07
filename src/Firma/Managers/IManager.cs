using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Dtos.Csv;
using Firma.Models;

namespace Firma.Managers
{
    public interface IManager
    {
        ManagerName Name { get; }
        Task ImportData();
    }
}