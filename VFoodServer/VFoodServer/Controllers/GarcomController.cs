using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;
using VFoodServer.DAO;
using VFoodServer.Models;
using VFoodServer.Models.Types;

namespace VFoodServer.Controllers
{
    public class GarcomController : ApiController
    {
        private GarcomDAO _dao;

        public GarcomController()
        {
            _dao = new GarcomDAO();
        }
        [Route("garcons/todos")]
        public IEnumerable<Garcom> Get()
        {
            return _dao.Listar();
        }

        [Route("garcom/insere")]
        public void Insere(Garcom garcom)
        {
            garcom.OperacaoSincronismo = OperacaoSincronismoType.Sincronizado;
            _dao.Insere(garcom);
        }

    }
}
