using AsmensRegistravimoSistemaI2.Models.UserControllerModels;

namespace AsmensRegistravimoSistemaI2.Database.Interfaces
{
    public interface IUserRepository
    {
        Guid CreateUser(User user);
        bool DeleteUser(Guid id);
        User? GetUser(string username);
        List<User> GetUsers();
    }
}