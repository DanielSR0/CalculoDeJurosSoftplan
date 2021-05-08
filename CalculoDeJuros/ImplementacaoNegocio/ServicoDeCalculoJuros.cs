using CalculoDeJuros.Negocio;
using Comum;
using Comum.ImplementacoesComunicacaoApi;
using System;
using System.Threading.Tasks;

namespace CalculoDeJuros.ImplementacaoNegocio
{
    /// <inheritdoc/>
    internal class ServicoDeCalculoJuros : IServicoDeCalculoJuros
    {
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


            var taxaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<IConsultaTaxaDeJuros>("TaxaJurosUrl");
            var consultaJuros = await taxaJurosApi.Get();

            if (consultaJuros.IsSuccessStatusCode)
            {
                var juros = consultaJuros.Content;
                var multiplicador = Math.Pow(1 + juros, meses);
                var resultado = valorInicial * multiplicador;
                resultado = Math.Truncate(resultado * 100) / 100;

                return resultado;
            }
            else
            {
                throw new ApplicationException("Não foi possível obter a taxa de juros. Houve um problema na comunicação com a API", consultaJuros.Error);
            }
        }
    }
}