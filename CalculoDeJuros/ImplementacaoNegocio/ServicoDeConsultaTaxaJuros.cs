using CalculoDeJuros.Negocio;
using Comum;
using Comum.ImplementacoesComunicacaoApi;
using Serilog;
using System;
using System.Threading.Tasks;

namespace CalculoDeJuros.ImplementacaoNegocio
{
    /// <inheritdoc/>
    internal class ServicoDeConsultaTaxaJuros : IServicoDeConsultaTaxaJuros
    {
        /// <inheritdoc/>
        public async Task<double> ObterTaxaAtual()
        {
            try
            {
                var taxaJurosApi = ComunicacaoAPIFactory.ObterComunicacaoComApi<IConsultaTaxaDeJuros>("TaxaJurosUrl");
                var consultaJuros = await taxaJurosApi.Get();

                if (consultaJuros.IsSuccessStatusCode)
                {
                    var juros = consultaJuros.Content;

                    return juros;
                }
                else
                {
                    throw consultaJuros.Error;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Houve um erro ao consultar a taxa de juros atual.", ex);

                throw;
            }
        }
    }
}