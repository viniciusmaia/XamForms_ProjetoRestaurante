using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VFood.Modelo;
using Xamarin.Forms;

namespace VFood.DAO
{
    public class BaseDAO<Model> where Model : BaseModel, new ()
    {
        protected string _pathDBFile;

        public BaseDAO()
        {
            _pathDBFile = DependencyService.Get<IControleArquivoDB>().Path;
            var connection = new SQLiteConnection(_pathDBFile);
            connection.CreateTable<Model>();
        }

        public virtual void Insere(Model modelo)
        {
            try
            {
                using (var connection = new SQLiteConnection(_pathDBFile))
                {
                    connection.Insert(modelo);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);

                throw new Exception("Falha ao inserir registro");
            }
        }

        public virtual void Atualiza(Model modelo)
        {
            try
            {
                using (var connection = new SQLiteConnection(_pathDBFile))
                {
                    connection.Update(modelo);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);

                throw new Exception("Falha ao atualizar registro");
            }
        }

        public virtual Model BuscaPorId(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(_pathDBFile))
                {
                    var modelo = connection.Find<Model>(id);

                    return modelo;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao buscar registro", e);
            }
        }

        public virtual IList<Model> Listar()
        {
            IList<Model> listaModel = null;

            try
            {
                using (var connection = new SQLiteConnection(_pathDBFile))
                {
                    listaModel = connection.Table<Model>().ToList();
                }

                return listaModel;
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao listar registros", e);
            }
        }

        public virtual bool Remove(long id)
        {
            try
            {
                using (var connection = new SQLiteConnection(_pathDBFile))
                {
                    int quantidadeObjetosRemovidos = connection.Delete<Model>(id);

                    return quantidadeObjetosRemovidos > 0 ? true : false;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Falha ao remover registro", e);
            }
        }

        public virtual bool Remove(Model modelo)
        {
            try
            {
                using (var connection = new SQLiteConnection(_pathDBFile))
                {
                    int quantidadeObjetosRemovidos = connection.Delete<Model>(modelo.IdLocal);

                    return quantidadeObjetosRemovidos > 0 ? true : false;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Falha ao remover registro", e);
            }
        }

    }
}
