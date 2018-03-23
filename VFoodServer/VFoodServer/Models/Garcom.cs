using System;
using VFoodServer.Models.Types;

namespace VFoodServer.Models
{
    public class Garcom : BaseModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public byte[] Foto { get; set; }
        public long? DispositivoId { get; set; }
        public long? EntityId { get; set; }
        public OperacaoSincronismoType OperacaoSincronismo { get; set; }

        public override bool Equals(object obj)
        {
            var garcom = obj as Garcom;
            return Id.Equals(garcom.Id);
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(DispositivoId + EntityId);
        }

    }
}