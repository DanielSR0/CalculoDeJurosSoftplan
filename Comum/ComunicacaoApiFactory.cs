using Microsoft.Extensions.Configuration;
using Refit;
using System.IO;

namespace Comum
{
    public sealed class ComunicacaoAPIFactory
    {
        private const string _appSettings = "appsettings.json";

        public static T ObterComunicacaoComApi<T>(string nomeConfigUrl) where T : IComunicacaoApi
        {
            var diretorio = Directory.GetCurrentDirectory();

            //TODO
            //var caminhoAppSettings = Path.Combine(diretorio, _appSettings);

            //if (!File.Exists(caminhoAppSettings))
            //{
            //    throw new FileNot
            //}

            var builder = new ConfigurationBuilder()
                .SetBasePath(diretorio)
                .AddJsonFile(_appSettings);

            var config = builder.Build();

            var url = config.GetSection(nomeConfigUrl).Value;

            var comunicacaoApi = RestService.For<T>(url);

            return comunicacaoApi;
        }
    }
}