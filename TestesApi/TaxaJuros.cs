using Comum;
using Comum.ImplementacoesComunicacaoApi;
using FluentAssertions;
using System.Net;
using Xunit;

namespace TestesApi
{
    public class TaxaJuros
    {
        [Theory]
        [InlineData(0.01)]
        public async void ObterTaxaDeJuros(double taxaEsperada)
        {
            var taxaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<IConsultaTaxaDeJuros>("TaxaJurosUrl");
            var consultaTaxa = await taxaJurosApi.Get();

            consultaTaxa.StatusCode.Should().Be(HttpStatusCode.OK);

            var taxaEncontrada = consultaTaxa.Content;

            taxaEncontrada.Should().Be(taxaEsperada);
        }
    }
}