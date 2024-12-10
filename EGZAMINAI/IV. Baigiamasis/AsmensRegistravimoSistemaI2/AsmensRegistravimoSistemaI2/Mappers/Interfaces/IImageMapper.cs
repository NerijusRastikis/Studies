using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.DTOs.Results;
using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;

namespace AsmensRegistravimoSistemaI2.Mappers.Interfaces
{
    public interface IImageMapper
    {
        ImageDTOResult Map(Image image);
        Image Map(ImageDTORequest imageRequest, Guid imageId);
    }
}