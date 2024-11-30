using ExternalAPI.DTOs;

namespace ExternalAPI.Services
{
    public class BookApiClient
    {
        public interface IBooksApiClient
        {
            Task<long?> CreateBook(string connectionId, BookApiRequest req);
            Task DeleteBook(string connectionId, int id);
            Task<BookApiResult?> GetBook(string connectionId, int bookId);
            Task<IEnumerable<BookApiResult>?> GetBooks(string connectionId);
            Task UpdateBook(string connectionId, int bookId, BookApiRequest req);
        }
        public class BooksApiClient : IBooksApiClient
        {
            private readonly ILogger<BooksApiClient> _logger;
            private readonly HttpClient _client;

            public BooksApiClient(ILogger<BooksApiClient> logger, HttpClient client)
            {
                _logger = logger;
                _client = client;
            }

            public async Task<IEnumerable<BookApiResult>?> GetBooks(string connectionId)
            {
                _client.DefaultRequestHeaders.Add("connectionId", connectionId);
                var response = await _client.GetFromJsonAsync<IEnumerable<BookApiResult>>("books");
                return response;
            }

            public async Task<BookApiResult?> GetBook(string connectionId, int bookId)
            {
                _client.DefaultRequestHeaders.Add("connectionId", connectionId);
                var response = await _client.GetFromJsonAsync<BookApiResult>($"books/{bookId}");
                return response;
            }

            public async Task<long?> CreateBook(string connectionId, BookApiRequest req)
            {
                _client.DefaultRequestHeaders.Add("connectionId", connectionId);
                var response = await _client.PostAsJsonAsync("books", req);
                if (response.IsSuccessStatusCode)
                {
                    BookApiResult? content = await response.Content.ReadFromJsonAsync<BookApiResult>();
                    return content!.Id;
                }
                return null;
            }
            public async Task UpdateBook(string connectionId, int bookId, BookApiRequest req)
            {
                _client.DefaultRequestHeaders.Add("connectionId", connectionId);
                await _client.PutAsJsonAsync($"books/{bookId}", req);
            }

            public Task DeleteBook(string connectionId, int id)
            {
                _client.DefaultRequestHeaders.Add("connectionId", connectionId);
                return _client.DeleteAsync($"books/{id}");
            }
        }
    }
}
