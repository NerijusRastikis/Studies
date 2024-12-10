using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.DTOs.Results;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;

namespace AsmensRegistravimoSistemaI2.Mappers
{
    public class GeneralInformationMapper : IGeneralInformationMapper
    {
        // For getting GI from DB
        public GeneralInformationDTOResult Map(GeneralInformation gI)
        {
            return new GeneralInformationDTOResult
            {
                FirstName = gI.FirstName,
                LastName = gI.LastName,
                PersonalCode = gI.PersonalCode,
                PhoneNumber = gI.PhoneNumber,
                Email = gI.Email,
            };
        }
        // For uploading GI to DB
        public GeneralInformation Map(GeneralInformationDTORequest gIrequest, Guid id)
        {
            return new GeneralInformation
            {
                Id = id,
                FirstName = gIrequest.FirstName,
                LastName = gIrequest.LastName,
                PersonalCode = gIrequest.PersonalCode,
                PhoneNumber = gIrequest.PhoneNumber,
                Email = gIrequest.Email,
            };
        }
    }
}
