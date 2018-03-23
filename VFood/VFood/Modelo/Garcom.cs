using Newtonsoft.Json;
using System;
using VFoodServer.Models.Types;

namespace VFood.Modelo
{
    public class Garcom : BaseModel
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public byte[] Foto { get; set; }
        public long? DispositivoId { get; set; }
        public long? EntityId { get; set; }
        public OperacaoSincronismoType OperacaoSincronismo { get; set; }

        public override bool Equals(object obj)
        {
            var garcom = obj as Garcom;
            return IdLocal.Equals(garcom.IdLocal);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(DispositivoId + EntityId);
        }

        [JsonIgnore]
        public string NomeCompleto
        {
            get { return Nome + " " + Sobrenome; }
        }
    }
}