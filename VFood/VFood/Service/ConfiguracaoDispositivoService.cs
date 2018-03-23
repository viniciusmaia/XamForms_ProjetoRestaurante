using Plugin.Settings;
using System.Threading.Tasks;
using VFood.Modelo;
using VFood.RESTClient;
using VFood.Util;

namespace VFood.Service
{
    public class ConfiguracaoDispositivoService
    {
        public ConfiguracaoDispositivo GetConfiguracao()
        {
            if (CrossSettings.Current.Contains(Constantes.EmailConfiguracaoKey) && CrossSettings.Current.Contains(Constantes.IdDispositivoConfiguracaoKey))
            {
                return new ConfiguracaoDispositivo
                {
                    Email = CrossSettings.Current.GetValueOrDefault(Constantes.EmailConfiguracaoKey, null),
                    IdLocal = CrossSettings.Current.GetValueOrDefault(Constantes.IdDispositivoConfiguracaoKey, 0L)
                };
            }

            return null;
        }

        public async Task<ConfiguracaoDispositivo> ObtemIdDispositivo(string email)
        {
            var restClient = new ConfiguracaoDispositivoRESTClient();
            var idDispositivo = await restClient.GetDispositivoIdAsync(email);
            CrossSettings.Current.AddOrUpdateValue(Constantes.EmailConfiguracaoKey, email);
            CrossSettings.Current.AddOrUpdateValue(Constantes.IdDispositivoConfiguracaoKey, idDispositivo.Value);

            return new ConfiguracaoDispositivo
            {
                Email = email,
                IdLocal = idDispositivo
            };             
        }
    }
}
