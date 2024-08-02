using MongoDB.Bson.Serialization.Attributes;

namespace Library.Entities
{
    public abstract class Mongeable
    {
        [BsonId]
        public String Id { get; set; }
        public Mongeable()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Mongeable(string id)
        {
            Id = id;
        }
    }
}
