using AsmensRegistravimoSistemaI2.DTOs.Results;

namespace AsmensRegistravimoSistemaI2.Database.Interfaces
{
    public interface IGIRepository
    {
        Guid CreateGI(GeneralInformation gI);
        GeneralInformation? GetGIById(Guid id);
        bool UpdateGI(GeneralInformation gI);
        bool DeleteGI(Guid id);
        GeneralInformationDTOResult GetGIByIdForClient(Guid id);
    }
}