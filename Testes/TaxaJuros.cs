using Comum;
using Comum.ImplementacoesComunicacaoApi;
using FluentAssertions;
using Xunit;

namespace Testes
{
    public class TaxaJuros
    {
        [Theory]
        [InlineData(0.01)]
        public async void ObterTaxaDeJuros(double taxaEsperada)
        {
            var taxaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<ITaxaJuros>("TaxaJurosUrl");
            var taxaEncontrada = await taxaJurosApi.Get();

            taxaEncontrada.Should().Be(taxaEsperada);
        }
    }
}