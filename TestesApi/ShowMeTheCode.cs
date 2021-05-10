using Comum;
using Comum.ImplementacoesComunicacaoApi;
using FluentAssertions;
using System.Net;
using Xunit;

namespace TestesApi
{
    public class ShowMeTheCode
    {
        [Fact]
        public async void ObterUrlGithub()
        {
            var urlEsperada = "https://github.com/DanielSR0/CalculoDeJurosSoftplan";

            var showMeTheCodeApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<ICalculoDeJuros>("CalculaJurosUrl");
            var consultaUrl = await showMeTheCodeApi.GetShowMeTheCode();

            consultaUrl.StatusCode.Should().Be(HttpStatusCode.OK);

            var urlEncontrada = consultaUrl.Content;

            urlEncontrada.Should().Be(urlEsperada);
        }
    }
}