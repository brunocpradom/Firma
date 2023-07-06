using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Dtos.Csv;
using Firma.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Firma.Tests.Specs.Services
{
    public class CsvParserServiceTest
    {
        [Test]
        public void ProcessCsvTest()
        {
            var logger = Mock.Of<ILogger<CsvParserService>>();
            CsvParserService csvParserService = new(logger);

            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            var oneAboveDirectory = Directory.GetParent(currentDirectory!.ToString());
            var twoAboveDirectory = Directory.GetParent(oneAboveDirectory!.ToString());
            string mockZipFilePath = Path.Combine(twoAboveDirectory!.ToString(), "TestUtils", "MockFiles", "csv");

            var response = csvParserService.ProcessCsv<CnaeCsvDto>(mockZipFilePath);
            response.First().Code.Should().Be("0111301");
        }
    }
}