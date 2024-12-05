using AsmensRegistravimoSistemaI2.Models.UserControllerModels;

namespace AsmensRegistravimoSistemaI2.Database.Repositories
{
    public class UserRepository
    {
        private readonly ARSDbContext _context;

        public UserRepository(ARSDbContext context)
        {
            _context = context;
        }
        public Guid CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var isExisting = _context.Users.Any(x => x.Username == user.Username);
            if (isExisting)
            {
                throw new ArgumentException("Username already exists");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }
        public User? GetUser(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public bool DeleteUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
