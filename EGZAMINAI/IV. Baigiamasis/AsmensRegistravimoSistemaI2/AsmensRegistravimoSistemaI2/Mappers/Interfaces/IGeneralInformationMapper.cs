using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.DTOs.Results;

namespace AsmensRegistravimoSistemaI2.Mappers.Interfaces
{
    public interface IGeneralInformationMapper
    {
        GeneralInformationDTOResult Map(GeneralInformation gI);
        GeneralInformation Map(GeneralInformationDTORequest gIrequest, Guid id);
    }
}