using MongoDB.Bson.Serialization.Attributes;

namespace Library.Entities{

    [BsonIgnoreExtraElements]
    public class Book : Mongeable {
        public Book(string title)
        {
            Title = title;
        }

        public Status Status { get;set;}
        public string Title {get;set;}
        public string Image {get;set;}
        public List<string>? Authors { get;set;}
        public string Sinopsis { get;set;}
        public int Pages { get; set;}

        public List<TranslatedString> TranslatedTitles { get;set;}
        public List<string>? ISBN { get; set; }
        public List<string>? People { get; internal set; }
        public List<string>? Time { get; internal set; }
        public List<string>? Place { get; internal set; }
    }

    
}