using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Firma.Tests.Integration.Fixtures
{
    public class ApiFixture
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
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas1.zip">Empresas1.zip</a>          </td><td align="right">2023-06-12 22:07  </td><td align="right"> 74M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas2.zip">Empresas2.zip</a>          </td><td align="right">2023-06-12 22:08  </td><td align="right"> 75M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas3.zip">Empresas3.zip</a>          </td><td align="right">2023-06-12 22:08  </td><td align="right"> 81M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas4.zip">Empresas4.zip</a>          </td><td align="right">2023-06-12 22:09  </td><td align="right"> 86M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas5.zip">Empresas5.zip</a>          </td><td align="right">2023-06-12 22:09  </td><td align="right"> 93M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas6.zip">Empresas6.zip</a>          </td><td align="right">2023-06-12 22:10  </td><td align="right"> 90M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas7.zip">Empresas7.zip</a>          </td><td align="right">2023-06-12 22:11  </td><td align="right"> 95M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas8.zip">Empresas8.zip</a>          </td><td align="right">2023-06-12 22:10  </td><td align="right"> 95M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Empresas9.zip">Empresas9.zip</a>          </td><td align="right">2023-06-12 22:11  </td><td align="right"> 91M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos0.zip">Estabelecimentos0.zip</a>  </td><td align="right">2023-06-12 22:19  </td><td align="right">1.0G</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos1.zip">Estabelecimentos1.zip</a>  </td><td align="right">2023-06-12 22:14  </td><td align="right">328M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos2.zip">Estabelecimentos2.zip</a>  </td><td align="right">2023-06-12 22:17  </td><td align="right">330M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos3.zip">Estabelecimentos3.zip</a>  </td><td align="right">2023-06-12 22:21  </td><td align="right">328M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos4.zip">Estabelecimentos4.zip</a>  </td><td align="right">2023-06-12 22:23  </td><td align="right">331M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos5.zip">Estabelecimentos5.zip</a>  </td><td align="right">2023-06-12 22:24  </td><td align="right">341M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos6.zip">Estabelecimentos6.zip</a>  </td><td align="right">2023-06-12 22:28  </td><td align="right">348M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos7.zip">Estabelecimentos7.zip</a>  </td><td align="right">2023-06-12 22:29  </td><td align="right">330M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos8.zip">Estabelecimentos8.zip</a>  </td><td align="right">2023-06-12 22:33  </td><td align="right">330M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Estabelecimentos9.zip">Estabelecimentos9.zip</a>  </td><td align="right">2023-06-12 22:34  </td><td align="right">328M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/layout.gif" alt="[   ]"></td><td><a href="LAYOUT_DADOS_ABERTOS_CNPJ.pdf">LAYOUT_DADOS_ABERTOS..&gt;</a></td><td align="right">2019-02-22 17:41  </td><td align="right">115K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Motivos.zip">Motivos.zip</a>            </td><td align="right">2023-06-12 22:33  </td><td align="right">1.1K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Municipios.zip">Municipios.zip</a>         </td><td align="right">2023-06-12 22:33  </td><td align="right"> 42K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Naturezas.zip">Naturezas.zip</a>          </td><td align="right">2023-06-12 22:33  </td><td align="right">1.5K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Paises.zip">Paises.zip</a>             </td><td align="right">2023-06-12 22:33  </td><td align="right">2.7K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Qualificacoes.zip">Qualificacoes.zip</a>      </td><td align="right">2023-06-12 22:33  </td><td align="right">1.0K</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Simples.zip">Simples.zip</a>            </td><td align="right">2023-06-12 22:39  </td><td align="right">192M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios0.zip">Socios0.zip</a>            </td><td align="right">2023-06-12 22:39  </td><td align="right">109M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios1.zip">Socios1.zip</a>            </td><td align="right">2023-06-12 22:40  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios2.zip">Socios2.zip</a>            </td><td align="right">2023-06-12 22:40  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios3.zip">Socios3.zip</a>            </td><td align="right">2023-06-12 22:40  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios4.zip">Socios4.zip</a>            </td><td align="right">2023-06-12 22:41  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios5.zip">Socios5.zip</a>            </td><td align="right">2023-06-12 22:41  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios6.zip">Socios6.zip</a>            </td><td align="right">2023-06-12 22:41  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios7.zip">Socios7.zip</a>            </td><td align="right">2023-06-12 22:42  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios8.zip">Socios8.zip</a>            </td><td align="right">2023-06-12 22:42  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios8.zip">Socios8.zip</a>            </td><td align="right">2023-06-12 22:42  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
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

        private byte[] MockDownloadFile()
        {
            {
                var currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
                var oneAboveDirectory = Directory.GetParent(currentDirectory!.ToString());
                var twoAboveDirectory = Directory.GetParent(oneAboveDirectory!.ToString());
                var mockZipFilePath = Path.Combine(twoAboveDirectory!.ToString(), "TestUtils", "MockFiles", "zip", "cnaes.zip");

                return File.ReadAllBytes(mockZipFilePath);
            }
        }
        public void CreateDownloadFileStub()
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
            server
                .Given(Request.Create().WithPath("/CNPJ/Cnaes.zip").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithHeader("Content-Type", "application/octet-stream")
                        .WithHeader("Content-Disposition", "attachment; filename=arquivo.txt")
                        .WithBody(MockDownloadFile())
                    );
        }

        [TearDown]
        public void StopServer()
        {
            server.Stop();
        }
    }
}