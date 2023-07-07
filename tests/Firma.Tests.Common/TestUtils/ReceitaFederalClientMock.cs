using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;

namespace Firma.Tests.Common.TestUtils;

public class MockedMessageHandler : HttpMessageHandler
{
    readonly IDictionary<string, HttpContent> responses;

    public MockedMessageHandler(IDictionary<string, HttpContent> responses) =>
        this.responses = responses;

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request.RequestUri is not null &&
            responses.TryGetValue(request.RequestUri.ToString(), out var content))
        {
            HttpResponseMessage httpResponseMessage = new()
            {
                Content = content,
            };

            return Task.FromResult(httpResponseMessage);
        }

        throw new InvalidOperationException("URL not mapped");
    }
}

public static class ReceitaFederalClientMock
{
    private static HttpContent MockTaxRegimeLinksHttpContent()
    {
        var html = """            
                <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 3.2 Final//EN">
                <html>
                <head>
                <title>Index of /CNPJ/regime_tributario</title>
                </head>
                <body>
                <h1>Index of /CNPJ/regime_tributario</h1>
                <table>
                <tr><th valign="top"><img src="/icons/blank.gif" alt="[ICO]"></th><th><a href="?C=N;O=D">Name</a></th><th><a href="?C=M;O=A">Last modified</a></th><th><a href="?C=S;O=A">Size</a></th><th><a href="?C=D;O=A">Description</a></th></tr>
                <tr><th colspan="5"><hr></th></tr>
                <tr><td valign="top"><img src="/icons/back.gif" alt="[PARENTDIR]"></td><td><a href="/CNPJ/">Parent Directory</a>       </td><td>&nbsp;</td><td align="right">  - </td><td>&nbsp;</td></tr>
                <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Imunes%20e%20isentas.zip">Imunes e isentas.zip</a>   </td><td align="right">2023-02-01 08:50  </td><td align="right">7.3M</td><td>&nbsp;</td></tr>
                <tr><td valign="top"><img src="/icons/unknown.gif" alt="[   ]"></td><td><a href="Leiaute%20dos%20Arquivos.odt">Leiaute dos Arquivos..&gt;</a></td><td align="right">2023-02-01 08:50  </td><td align="right"> 20K</td><td>&nbsp;</td></tr>
                <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Lucro%20Arbitrado.zip">Lucro Arbitrado.zip</a>    </td><td align="right">2023-02-01 08:50  </td><td align="right"> 51K</td><td>&nbsp;</td></tr>
                <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Lucro%20Presumido.zip">Lucro Presumido.zip</a>    </td><td align="right">2023-02-01 08:50  </td><td align="right"> 26M</td><td>&nbsp;</td></tr>
                <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Lucro%20Real.zip">Lucro Real.zip</a>         </td><td align="right">2023-02-01 08:50  </td><td align="right">6.8M</td><td>&nbsp;</td></tr>
                <tr><th colspan="5"><hr></th></tr>
                </table>
                </body></html>
                """;
        HttpContent content = new StringContent(html, Encoding.UTF8, "application/json");
        return content;
    }

    private static HttpContent MockMainLinksHttpContent()
    {
        var html = """
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
                    <tr><td valign="top"><img src="/icons/compressed.gif" alt="[   ]"></td><td><a href="Socios9.zip">Socios9.zip</a>            </td><td align="right">2023-06-12 22:42  </td><td align="right"> 47M</td><td>&nbsp;</td></tr>
                    <tr><td valign="top"><img src="/icons/folder.gif" alt="[DIR]"></td><td><a href="regime_tributario/">regime_tributario/</a>     </td><td align="right">2023-02-01 12:56  </td><td align="right">  - </td><td>&nbsp;</td></tr>
                    <tr><th colspan="5"><hr></th></tr>
                    </table>
                    </body></html>
                    """;
        HttpContent content = new StringContent(html, Encoding.UTF8, "application/json");
        return content;
    }

    public static ReceitaFederalClient MockClient(IDictionary<string, HttpContent> data) =>
        CreateClient(new MockedMessageHandler(data));

    public static ReceitaFederalClient MockClient(string url, HttpContent content) =>
        CreateClient(new MockedMessageHandler(
            new Dictionary<string, HttpContent>
            {
                [url] = content,
            }
        ));

    static ReceitaFederalClient CreateClient(HttpMessageHandler httpMessageHandlerMock)
    {
        var httpClient = new HttpClient(httpMessageHandlerMock);
        var logger = Mock.Of<ILogger<ReceitaFederalClient>>();
        return new(logger, httpClient);
    }

    const string baseUrl = "http://200.152.38.155";

    public static ReceitaFederalClient MockGetMainLinks()
    {
        var content = MockMainLinksHttpContent();
        return MockClient($"{baseUrl}/CNPJ/", content);
    }

    public static ReceitaFederalClient MockGetTaxRegimeLinks()
    {
        var content = MockTaxRegimeLinksHttpContent();
        return MockClient($"{baseUrl}/CNPJ/regime_tributario/", content);
    }

    public static ReceitaFederalClient MockDownloadFile()
    {
        var mockZipFilePath = Path.GetFullPath(
            "../../../TestUtils/MockFiles/cnaes.zip",
            Directory.GetCurrentDirectory()
        );

        var fileContent = File.ReadAllBytes(mockZipFilePath);
        var memoryStream = new MemoryStream(fileContent);

        return MockClient(new Dictionary<string, HttpContent>
            {
                [$"{baseUrl}/CNPJ/"] = MockMainLinksHttpContent(),
                [$"{baseUrl}/CNPJ/Cnaes.zip"] = new StreamContent(memoryStream),
            }
        );
    }
}