using BooksApi.Models;

namespace BooksApi.Services.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string username);
        void SaveUser(User user);
    }
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public void SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
