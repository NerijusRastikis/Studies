using P103_ExternalApi.Dtos;

namespace P103_ExternalApi.Services
{
    public class AuthorsApiClient
    {
        private readonly ILogger<AuthorsApiClient> _logger;
        private readonly HttpClient _client;

        public AuthorsApiClient(ILogger<AuthorsApiClient> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }
        public async Task<IEnumerable<AuthorApiResult>?> GetBooks(string connectionId)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            var response = await _client.GetFromJsonAsync<IEnumerable<AuthorApiResult>>("books");
            return response;
        }

        public async Task<AuthorApiResult?> GetBook(string connectionId, int bookId)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            var response = await _client.GetFromJsonAsync<AuthorApiResult>($"books/{bookId}");
            return response;
        }

        public async Task<long?> CreateBook(string connectionId, AuthorApiRequest req)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            var response = await _client.PostAsJsonAsync("books", req);
            if (response.IsSuccessStatusCode)
            {
                AuthorApiResult? content = await response.Content.ReadFromJsonAsync<AuthorApiResult>();
                return content!.Id;
            }
            return null;
        }
        public async Task UpdateBook(string connectionId, int authorId, AuthorApiRequest req)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            await _client.PutAsJsonAsync($"books/{authorId}", req);
        }

        public Task DeleteBook(string connectionId, int authorId)
        {
            _client.DefaultRequestHeaders.Add("connectionId", connectionId);
            return _client.DeleteAsync($"books/{authorId}");
        }
    }
}
