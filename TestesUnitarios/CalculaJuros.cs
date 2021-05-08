using CalculoDeJuros.ImplementacaoNegocio;
using FluentAssertions;
using System;
using Xunit;

namespace TestesUnitarios
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
            var calculaJuros = new ServicoDeCalculoJuros();
            var jurosCalculado = await calculaJuros.CalcularJuros(valorInicial, meses);

            jurosCalculado.Should().Be(jurosEsperado);
        }

        [Theory]
        [InlineData(0, 10, "Valor inicial deve ser maior que zero (Parameter 'valorInicial')")]
        [InlineData(478, 0, "Número de meses deve ser maior que zero (Parameter 'meses')")]
        public async void CalcularJurosParametrosInvalidos(double valorInicial, int meses, string erroValidacao)
        {
            var calculaJuros = new ServicoDeCalculoJuros();

            try
            {
                var jurosCalculado = await calculaJuros.CalcularJuros(valorInicial, meses);
            }
            catch (ArgumentException ex)
            {
                ex.Message.Should().Be(erroValidacao);
            }
        }
    }
}