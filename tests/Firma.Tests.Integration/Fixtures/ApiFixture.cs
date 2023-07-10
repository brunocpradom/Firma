using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Firma.Tests.Integration.Fixtures
{
    public class ApiFixture : ServicesFixture
    {
        private WireMockServer server;

        public string htmlMock()
        {
            return """
                    <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2 Final//EN">
                    <html>
                    <head>
                    <title>Index of /CNPJ</title>
                    </head>
                    <body>
                    <h1>Index of /CNPJ</h1>
                    <table>
                    <tr><th valign="top"><img src="/icons/blank.gif" alt="[ICO]"></th><th><a href="?C=N;O=D">Name</a></th><th><a href="?C=M;O=A">Last modified</a></th><th><a href="?C=S;O=A">Size</a></th><th><a href="?C=D;O=A">Description</a></th></tr>
                    <tr><th colspan="5"><hr></th></tr>
                    <tr><td valign="top"><img src="/icons/back.gif" alt="[PARENTDIR]"></td><td><a href="/">Parent Directory</a>       </td><td>&nbsp;</td><td align="right">  - </td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Cnaes.zip">Cnaes.zip</a>              </td><td align="right">2023-06-12 22:05  </td><td align="right"> 22K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas0.zip">Empresas0.zip</a>          </td><td align="right">2023-06-12 22:08  </td><td align="right">257M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos0.zip">Estabelecimentos0.zip</a>  </td><td align="right">2023-06-12 22:19  </td><td align="right">1.0G</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/layout.gif" alt="[   ]"></td><td><a href="LAYOUT_DADOS_ABERTOS_CNPJ.pdf">LAYOUT_DADOS_ABERTOS..&gt;</a></td><td align="right">2019-02-22 17:41  </td><td align="right">115K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Motivos.zip">Motivos.zip</a>            </td><td align="right">2023-06-12 22:33  </td><td align="right">1.1K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Municipios.zip">Municipios.zip</a>         </td><td align="right">2023-06-12 22:33  </td><td align="right"> 42K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Naturezas.zip">Naturezas.zip</a>          </td><td align="right">2023-06-12 22:33  </td><td align="right">1.5K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Paises.zip">Paises.zip</a>             </td><td align="right">2023-06-12 22:33  </td><td align="right">2.7K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Qualificacoes.zip">Qualificacoes.zip</a>      </td><td align="right">2023-06-12 22:33  </td><td align="right">1.0K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Simples.zip">Simples.zip</a>            </td><td align="right">2023-06-12 22:39  </td><td align="right">192M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios0.zip">Socios0.zip</a>            </td><td align="right">2023-06-12 22:39  </td><td align="right">109M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/folder.gif" alt="[DIR]"></td><td><a href="regime_tributario/">regime_tributario/</a>     </td><td align="right">2023-02-01 12:56  </td><td align="right">  - </td><td>&nbsp;</td></tr>
                    <tr><th colspan="5"><hr></th></tr>
                    </table>
                    </body></html>
                    """;
        }
        [SetUp]
        public void StartServer()
        {
            server = WireMockServer.Start(
                new WireMockServerSettings
                {
                    Urls = new[] { "http://localhost:8443" } // Defina o host do WireMock aqui
                }
            );
        }


        private byte[] MockDownloadFile(string fileName)
        {
            {
                var mockZipFilePath = Path.Combine(projectPath, "TestUtils", "MockFiles", "zip", fileName);
                return File.ReadAllBytes(mockZipFilePath);
            }
        }
        public void CreateGetMainLinkStub()
        {
            server
                .Given(Request.Create().WithPath("/CNPJ/").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithHeader("Content-Type", "application/octet-stream")
                        .WithHeader("Content-Disposition", "attachment; filename=arquivo.txt")
                        .WithBody(htmlMock())
                    );
        }
        public void CreateDownloadFileStub(string fileName)
        {
            CreateGetMainLinkStub();
            server
                .Given(Request.Create().WithPath($"/CNPJ/{fileName}").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithHeader("Content-Type", "application/octet-stream")
                        .WithHeader("Content-Disposition", "attachment; filename=arquivo.txt")
                        .WithBody(MockDownloadFile(fileName))
                    );
        }

        [TearDown]
        public void StopServer()
        {
            server.Stop();
        }
    }
}