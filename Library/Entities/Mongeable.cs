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

        public Mongeable(string id, bool hash = false)
        {
            if (hash)
                id = CreateMD5(id);
            Id = id;
        }

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes); // .NET 5 +
        }
        
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
