using ConsultaTaxaDeJuros.Consultas;
using System.Threading.Tasks;

namespace ConsultaTaxaDeJuros.Dados
{
    /// <inheritdoc/>
    internal class ConsultaDeTaxaJuros : IConsultaDeTaxaJuros
    {
        /// <inheritdoc/>
        public Task<double> BuscarTaxaJuros()
        {
            return Task.FromResult(0.01);
        }
    }
}