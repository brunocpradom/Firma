using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Services;
using Moq;

namespace Firma.Tests.Integration.TestUtils.Mocks
{
    public class MockReceitaFederalClient
    {
        public ReceitaFederalClient rfClientMock(string fileName)
        {
            var rfClientMock = new Mock<ReceitaFederalClient>();
            rfClientMock
                .Setup(client => client.GetMainLinks())
                .ReturnsAsync(new List<string> { "link1" });
            rfClientMock
                .Setup(client => client.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(MockDownloadFile(fileName));

            return rfClientMock.Object;
        }

        public string MockDownloadFile(string fileName)
        {
            var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
            var oneAboveDirectory = Directory.GetParent(currentDirectory!.ToString());
            var twoAboveDirectory = Directory.GetParent(oneAboveDirectory!.ToString());
            var mockZipFilePath = Path.Combine(twoAboveDirectory!.ToString(), "TestUtils", "MockFiles", "zip", fileName);
            Console.WriteLine("mockfilepath");
            Console.WriteLine(mockZipFilePath);
            File.Copy(mockZipFilePath, Path.Combine(Path.GetTempPath(), "Cnae", fileName), true);
            return mockZipFilePath;
        }
    }
}