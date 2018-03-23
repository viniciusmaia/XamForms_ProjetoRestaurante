using Newtonsoft.Json;
using SQLite;

namespace VFood.Modelo
{
    public abstract class BaseModel
    {
        [PrimaryKey, AutoIncrement, JsonIgnore]
        public long? IdLocal { get; set; }
    }
}
