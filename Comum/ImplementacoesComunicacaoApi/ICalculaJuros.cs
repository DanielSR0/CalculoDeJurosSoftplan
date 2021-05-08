using Refit;
using System.Threading.Tasks;

namespace Comum.ImplementacoesComunicacaoApi
{
    public interface ICalculaJuros : IComunicacaoApi
    {
        [Get("/calculaJuros")]
        Task<double> Get(double valorInicial, int meses);
    }
}