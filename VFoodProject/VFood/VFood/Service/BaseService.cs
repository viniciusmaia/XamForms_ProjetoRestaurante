using VFood.DAO;
using VFood.Modelo;

namespace VFood.Service
{
    public class BaseService<Model, DAO> where Model : BaseModel, new() where DAO : BaseDAO<Model>, new()
    {
        protected DAO _dao;

        public BaseService()
        {
            _dao = new DAO();
        }

        protected virtual void Insere(Model modelo)
        {
            _dao.Insere(modelo);
        }

        protected virtual void Atualiza(Model modelo)
        {
            _dao.Atualiza(modelo);
        }

        public virtual void Salva(Model modelo)
        {
            if (modelo.Id == null)
            {
                Insere(modelo);
            }
            else
            {
                Atualiza(modelo);
            }
        }

        public virtual Model Busca(long id)
        {
            return _dao.BuscaPorId(id);
        }

        public virtual bool Remove(long id)
        {
            return _dao.Remove(id);
        }

        public virtual bool Remove(Model model)
        {
            return _dao.Remove(model);
        }
    }
}
