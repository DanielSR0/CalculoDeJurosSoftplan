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
            var taxaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<ITaxaJuros>("TaxaJurosUrl");
            var juros = await taxaJurosApi.Get();

            var multiplicador = Math.Pow(1 + juros, meses);
            var resultado = valorInicial * multiplicador;
            resultado = Math.Truncate(resultado * 100) / 100;

            return resultado;
        }
    }
}