using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.Tests.Common
{
    public class MockFileProvider
    {
        public string GetMockFilesPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Files");
        }
    }
}