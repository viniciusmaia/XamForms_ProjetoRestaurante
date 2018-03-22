using System.Collections.Generic;
using VFoodServer.Models;

namespace VFoodServer.DAO
{
    public class GarcomDAO
    {
        private VFoodContext _context;

        public GarcomDAO()
        {
            _context = new VFoodContext();
        }

        public IEnumerable<Garcom> Listar()
        {
            return _context.Garcons;
        }

        public void Insere(Garcom garcom)
        {
            _context.Garcons.Add(garcom);
            _context.SaveChanges();
        }
    }
}