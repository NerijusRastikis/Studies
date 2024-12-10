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
        public User? GetUser(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            var selectedUser = _context.Users.FirstOrDefault(x => x.Username == username);
            var selectedUserId = selectedUser.Id;
            selectedUser.UserGeneralInformation = _context.GeneralInfos.FirstOrDefault(x => x.Id == selectedUserId);
            selectedUser.UserGeneralInformation.GIAddress = _context.Addresses.FirstOrDefault(x => x.Id == selectedUserId);
            return selectedUser;
        }
        public List<string> GetUsers()
        {
            List<string> listOfUsers = new List<string>();
            foreach (var user in _context.Users.ToList())
            {
                listOfUsers.Add(user.Username);
            }
            return listOfUsers;
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
