using CalculoDeJuros.Negocio;
using System;
using System.Threading.Tasks;

namespace CalculoDeJuros.ImplementacaoNegocio
{
    /// <inheritdoc/>
    internal class ServicoDeCalculoJuros : IServicoDeCalculoJuros
    {
        private readonly IServicoDeConsultaTaxaJuros _servicoDeConsultaTaxaJuros;

        public ServicoDeCalculoJuros(IServicoDeConsultaTaxaJuros servicoDeConsultaTaxaJuros)
        {
            _servicoDeConsultaTaxaJuros = servicoDeConsultaTaxaJuros;
        }

        /// <inheritdoc/>
        public async Task<double> CalcularJuros(double valorInicial, int meses)
        {
            if (valorInicial <= 0)
            {
                throw new ArgumentException("Valor inicial deve ser maior que zero", nameof(valorInicial));
            }

            if (meses <= 0)
            {
                throw new ArgumentException("Número de meses deve ser maior que zero", nameof(meses));
            }

            var juros = await _servicoDeConsultaTaxaJuros.ObterTaxaAtual();

            var multiplicador = Math.Pow(1 + juros, meses);
            var resultado = valorInicial * multiplicador;
            resultado = Math.Truncate(resultado * 100) / 100;

            return resultado;
        }
    }
}