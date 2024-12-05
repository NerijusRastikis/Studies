using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.Models.UserControllerModels;

namespace AsmensRegistravimoSistemaI2.Mappers.Interfaces
{
    public interface IUserMapper
    {
        User Map(UserDTORequest dto);
    }
}