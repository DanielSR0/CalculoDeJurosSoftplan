using ConsultaTaxaDeJuros.Dados;
using FluentAssertions;
using Xunit;

namespace TestesUnitarios
{
    public class TaxaJuros
    {
        [Theory]
        [InlineData(0.01)]
        public async void ObterTaxaDeJuros(double taxaEsperada)
        {
            var consultaDeTaxaJuros = new ConsultaDeTaxaJuros();
            var taxaEncontrada = await consultaDeTaxaJuros.BuscarTaxaJuros();

            taxaEncontrada.Should().Be(taxaEsperada);
        }
    }
}