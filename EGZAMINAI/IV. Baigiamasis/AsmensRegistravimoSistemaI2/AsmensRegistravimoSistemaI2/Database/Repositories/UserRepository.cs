using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Database.Repositories
{
    public class UserRepository : IUserRepository
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
        public User? GetUserById(Guid id)
        {
            if (id != null)
            {
                return _context.Users.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }
        public User? GetUserByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            var selectedUser = _context.Users
                .FirstOrDefault(x => x.Username.Trim().ToLower() == username.Trim().ToLower());
            if (selectedUser == null)
            {
                return null; // CIA DAR PAGALVOK
            }

            selectedUser.GeneralInformation = _context.GeneralInfos.FirstOrDefault(x => x.Id == selectedUser.Id);

            if (selectedUser.GeneralInformation != null)
            {
                selectedUser.GeneralInformation.GIAddress = _context.Addresses.FirstOrDefault(x => x.Id == selectedUser.Id);
            }

            return selectedUser;
        }

        public List<string> GetUsers()
        {
            List<string> listOfUsers = _context.Users.Select(u => u.Username).ToList();
            return listOfUsers;
        }
        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
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

        //List<User> IUserRepository.GetUsers()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
