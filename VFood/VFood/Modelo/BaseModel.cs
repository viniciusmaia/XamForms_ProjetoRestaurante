using SQLite;

namespace VFood.Modelo
{
    public abstract class BaseModel
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }
    }
}
