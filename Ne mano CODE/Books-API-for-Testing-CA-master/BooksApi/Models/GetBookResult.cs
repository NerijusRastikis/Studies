namespace BooksApi.Models
{
    public class GetBookResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Pages { get; set; }

        public int Year { get; set; }

        public string ISBN { get; set; }

        public IList<string> Authors { get; set; }
    }
}
