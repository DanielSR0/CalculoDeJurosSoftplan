using Comum;
using Comum.ImplementacoesComunicacaoApi;
using FluentAssertions;
using System.Net;
using Xunit;

namespace TestesApi
{
    public class CalculaJuros
    {
        [Theory]
        [InlineData(10, 3, 10.3)]
        [InlineData(24, 6, 25.47)]
        [InlineData(100, 5, 105.10)]
        [InlineData(160, 14, 183.91)]
        [InlineData(206.49, 23, 259.59)]
        [InlineData(380, 22, 472.99)]
        [InlineData(189, 58, 336.59)]
        [InlineData(548.17, 96, 1424.84)]
        public async void CalcularJuros(double valorInicial, int meses, double jurosEsperado)
        {
            var calculaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<ICalculoDeJuros>("CalculaJurosUrl");
            var jurosCalculadoResponse = await calculaJurosApi.GetCalculaJuros(valorInicial, meses);

            jurosCalculadoResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var jurosCalculado = jurosCalculadoResponse.Content;

            jurosCalculado.Should().Be(jurosEsperado);
        }

        [Theory]
        [InlineData(0, 10, "Valor inicial deve ser maior que zero (Parameter 'valorInicial')")]
        [InlineData(478, 0, "Número de meses deve ser maior que zero (Parameter 'meses')")]
        public async void CalcularJurosParametrosInvalidos(double valorInicial, int meses, string erroValidacao)
        {
            var calculaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<ICalculoDeJuros>("CalculaJurosUrl");
            var jurosCalculadoResponse = await calculaJurosApi.GetCalculaJuros(valorInicial, meses);

            jurosCalculadoResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var mensagemErro = jurosCalculadoResponse.Error.Content;

            mensagemErro.Should().Be(erroValidacao);
        }

        [Fact]
        public async void ChamarEndpointInexistente()
        {
            var calculaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<ICalculoDeJurosParaTestes>("CalculaJurosUrl");
            var jurosCalculadoResponse = await calculaJurosApi.NaoEncontrado();

            jurosCalculadoResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}