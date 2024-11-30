namespace P004.DTOs
{
    public class BookAPIRequest
    {
        public string Title { get; set; }
        public List<int> Authors { get; set; }
        public List<string> Genres { get; set; }
        public int Year { get; set; }
    }
}
