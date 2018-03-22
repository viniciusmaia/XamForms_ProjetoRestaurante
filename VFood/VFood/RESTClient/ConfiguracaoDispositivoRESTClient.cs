using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using VFood.Modelo;

namespace VFood.RESTClient
{
    public class ConfiguracaoDispositivoRESTClient
    {
        private HttpClient client;
        public ConfiguracaoDispositivo ConfiguracaoDispositivo
        {
            get; set;
        }

        public ConfiguracaoDispositivoRESTClient()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<long?> GetDispositivoIdAsync(string eMail)
        {
            long? id = null;
            // Testei em uma rede esta URL e por problema com a configuração troquei o domínio para o IP e funcionou.Observe também o HTTPS
            var uri = new Uri(string.Format("http://vfood.azurewebsites.net//dispositivos/configuracao?email={0}", eMail));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                id = JsonConvert.DeserializeObject<long>(content);
            }
            return id;
        }
    }
}
