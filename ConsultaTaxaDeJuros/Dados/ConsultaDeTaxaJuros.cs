using ConsultaTaxaDeJuros.Consultas;

namespace ConsultaTaxaDeJuros.Dados
{
    /// <inheritdoc/>
    internal class ConsultaDeTaxaJuros : IConsultaDeTaxaJuros
    {
        /// <inheritdoc/>
        public double BuscarTaxaJuros()
        {
            return 0.01;
        }
    }
}