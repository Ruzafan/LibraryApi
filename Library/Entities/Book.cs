using MongoDB.Bson.Serialization.Attributes;

namespace Library.Entities{

    [BsonIgnoreExtraElements]
    public class Book : Mongeable {

        public Book(string title, bool hash = false) : base(title,hash)
        {
            Title = title;
        }
        public required Status Status { get;set;}
        public string Title {get; set;}
        public required string Image {get; set;}
        public List<string>? Authors { get; set;}
        public string? Sinopsis { get; set;}
        public float Rating { get; set;}
        
        public List<string>? Genres { get; internal set; }
        public string CreatedBy {get;set;}
        public int Pages {get;set;}
        
    }

    
}