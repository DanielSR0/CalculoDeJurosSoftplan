using Refit;
using System.Threading.Tasks;

namespace Comum.ImplementacoesComunicacaoApi
{
    public interface ITaxaJuros : IComunicacaoApi
    {
        [Get("/taxaJuros")]
        public Task<double> Get();
    }
}