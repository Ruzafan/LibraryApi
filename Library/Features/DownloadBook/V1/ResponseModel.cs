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
        public string[] isbn { get; set; }
        public string[] language { get; set; }
        public int number_of_pages_median { get; set; }
        public string title { get; set; }
        public string title_suggest { get; set; }
        public string[] person { get; set; }
        public string[] time { get; set; }
        public string[] place { get; set; }
        public decimal ratings_average { get; set; }
    }

}
