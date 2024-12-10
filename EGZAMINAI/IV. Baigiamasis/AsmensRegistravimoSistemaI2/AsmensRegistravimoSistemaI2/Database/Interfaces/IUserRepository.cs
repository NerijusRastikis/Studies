using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Database.Interfaces
{
    public interface IUserRepository
    {
        Guid CreateUser(User user);
        bool DeleteUser(Guid id);
        User? GetUser(string username);
        List<string> GetUsers();
    }
}