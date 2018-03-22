using System.Web.Http;
using VFoodServer.DAO;

namespace VFoodServer.Controllers
{
    public class ConfiguracaoDispositivoController : ApiController
    {
        private ConfiguracaoDispositivoDAO _dao;

        public ConfiguracaoDispositivoController()
        {
            _dao = new ConfiguracaoDispositivoDAO();
        }

        [Route("dispositivos/configuracao")]
        public long Get(string email)
        {
            return (long)_dao.Insere(email).Id;
        }
    }
}
