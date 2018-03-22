using System.Data.Entity;
using VFoodServer.Models;

namespace VFoodServer.DAO
{
    public class VFoodContext : DbContext
    {
        public VFoodContext() : base("vfoodconnection")
        {
        }
        public DbSet<Garcom> Garcons { get; set; }
        public DbSet<ConfiguracaoDispositivo> ConfiguracoesDispositivos { get; set; }
}
}