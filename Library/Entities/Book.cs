using MongoDB.Bson.Serialization.Attributes;

namespace Library.Entities{

    [BsonIgnoreExtraElements]
    public class Book : Mongeable {
        public Book(string title)
        {
            Id = CreateMD5(title);
            Title = title;
        }

        public Status Status { get;set;}
        public string Title {get;set;}
        public string Image {get;set;}
        public List<string> Authors { get;set;}
        public string Sinopsis { get;set;}
        public int Pages { get; set;}

        public List<TranslatedString> TranslatedTitles { get;set;}
        public List<string> ISBN { get; set; }
        public List<string> People { get; internal set; }
        public List<string> Time { get; internal set; }
        public List<string> Place { get; internal set; }

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
    }

    
}