using Newtonsoft.Json;
using System;
using VFoodServer.Models.Types;

namespace VFood.Modelo
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}