using Comum;
using Comum.ImplementacoesComunicacaoApi;
using FluentAssertions;
using Xunit;

namespace Testes
{
    public class CalculaJuros
    {
        [Theory]
        [InlineData(0, 10, 0)]
        [InlineData(478, 0, 478)]
        [InlineData(10, 3, 10.3)]
        [InlineData(24, 6, 25.47)]
        [InlineData(160, 14, 183.91)]
        [InlineData(206.49, 23, 259.59)]
        [InlineData(380, 22, 472.99)]
        [InlineData(189, 58, 336.59)]
        [InlineData(548.17, 96, 1424.84)]
        public async void CalcularJuros(double valorInicial, int meses, double jurosEsperado)
        {
            var calculaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<ICalculaJuros>("CalculaJurosUrl");
            var jurosCalculado = await calculaJurosApi.Get(valorInicial, meses);

            jurosCalculado.Should().Be(jurosEsperado);
        }
    }
}