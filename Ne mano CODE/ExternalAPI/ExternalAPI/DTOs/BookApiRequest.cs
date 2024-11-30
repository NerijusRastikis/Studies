namespace ExternalAPI.DTOs
{
    public class BookApiRequest
    {
        public string Title { get; set; }
        public List<int> Authors { get; set; }
        public List<string> Genres { get; set; }
        public int Year { get; set; }
    }
}
