using Comum;
using Comum.ImplementacoesComunicacaoApi;
using FluentAssertions;
using Xunit;

namespace Testes
{
    public class ShowMeTheCode
    {
        [Fact]
        public async void ObterUrlGithub()
        {
            var urlEsperada = "https://github.com/DanielSR0/CalculoDeJurosSoftplan";

            var showMeTheCodeApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<IShowMeTheCode>("CalculaJurosUrl");
            var urlEncontrada = await showMeTheCodeApi.Get();

            urlEncontrada.Should().Be(urlEsperada);
        }
    }
}
