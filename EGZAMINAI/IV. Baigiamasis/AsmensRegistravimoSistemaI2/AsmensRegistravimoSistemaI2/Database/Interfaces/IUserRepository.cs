using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Database.Interfaces
{
    public interface IUserRepository
    {
        Guid CreateUser(User user);
        bool DeleteUser(Guid id);
        User? GetUserByUsername(string username);
        User? GetUserById(Guid id);
        List<User> GetUsers();
        bool UpdateUser(User user);
    }
}