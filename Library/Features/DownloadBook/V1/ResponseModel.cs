namespace Library.Features.DownloadBook.V1
{
    public class ResponseModel
    {
        public int numFound { get; set; }
        public ResponseDocument[] docs { get; set; }
    }

    public class ResponseDocument
    {
        public string[] author_name { get; set; }
        public int cover_i { get; set; }
        public string key { get; set; }
        public string[] language { get; set; }
        public string title { get; set; }
        public float ratings_average { get; set; }
    }
}
