using System.Linq;
using VFoodServer.Models;

namespace VFoodServer.DAO
{
    public class ConfiguracaoDispositivoDAO
    {
        private VFoodContext _context;

        public ConfiguracaoDispositivoDAO()
        {
            _context = new VFoodContext();
        }

        public ConfiguracaoDispositivo Insere(string email)
        {
            var configuracao = BuscaPorEmail(email);

            if (configuracao == null)
            {
                configuracao = _context.ConfiguracoesDispositivos.Add(new ConfiguracaoDispositivo()
                {
                    Email = email
                });

                _context.SaveChanges();
            }

            return configuracao;
        }

        private ConfiguracaoDispositivo BuscaPorEmail(string email)
        {
            return _context.ConfiguracoesDispositivos.Where(c => c.Email.Equals(email)).FirstOrDefault();
        }
    }
}