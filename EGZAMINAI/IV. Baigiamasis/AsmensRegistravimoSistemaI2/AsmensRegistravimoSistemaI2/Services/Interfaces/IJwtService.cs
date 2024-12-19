using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.Services.Interfaces
{
    public interface IJwtService
    {
        string GetJwtToken(User user);
    }
}