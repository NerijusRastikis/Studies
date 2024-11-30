using P0004.DTOs;
using P004.DTOs;

namespace P0004.Services
{
    public interface IBooksAPIClient
    {
        Task<long?> CreateBook(string connectionId, BookAPIResult req);
        Task<BookAPIResult?> GetBook(string connectionId, int bookId);
        Task<IEnumerable<BookAPIResult>?> GetBooks(string connectionId);
        Task<BookAPIResult> UpdateBook(string connectionId, BookAPIResult req);
    }
    public class BooksApiClient : IBooksAPIClient
    {
        private readonly ILogger<BooksApiClient> _logger;
        private readonly HttpClient _client;

        public BooksApiClient(ILogger<BooksApiClient> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IEnumerable<BookAPIResult>?> GetBooks(string connectionId)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            var response = await _client.GetFromJsonAsync<IEnumerable<BookAPIResult>>("books");
            return response;
        }

        public async Task<BookAPIResult?> GetBook(string connectionId, int bookId)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            var response = await _client.GetFromJsonAsync<BookAPIResult>($"books/{bookId}");
            return response;
        }

        public async Task<long?> CreateBook(string connectionId, BookAPIResult req)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            var response = await _client.PostAsJsonAsync("books", req);
            if (response.IsSuccessStatusCode)
            {
                BookAPIResult? content = await response.Content.ReadFromJsonAsync<BookAPIResult>();
                return content!.Id;
            }
            return null;
        }
        public async Task UpdateBook(string connectionId, BookAPIResult req, int bookId)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            var response = await _client.PutAsJsonAsync($"books/{bookId}", req);
            if (response.IsSuccessStatusCode)
            {
                BookAPIResult? content = await response.Content.ReadFromJsonAsync<BookAPIResult>();
            }
        }
    }
}
