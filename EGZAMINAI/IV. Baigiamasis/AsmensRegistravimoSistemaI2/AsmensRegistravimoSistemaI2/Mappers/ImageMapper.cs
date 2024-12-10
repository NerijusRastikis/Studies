using AsmensRegistravimoSistemaI2.DTOs.Requests;
using AsmensRegistravimoSistemaI2.DTOs.Results;
using AsmensRegistravimoSistemaI2.Mappers.Interfaces;
using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using System;

namespace AsmensRegistravimoSistemaI2.Mappers
{
    public class ImageMapper : IImageMapper
    {
        // For getting image from DB
        public ImageDTOResult Map(Image image)
        {
            return new ImageDTOResult
            {
                Username = image.Username,
                Photo = image.Photo,
            };
        }
        // For uploading image
        public Image Map(ImageDTORequest imageRequest, Guid imageId)
        {
            using var stream = new MemoryStream();
            imageRequest.Photo.CopyTo(stream);
            var imageBytes = stream.ToArray();
            return new Image
            {
                Id = imageId,
                Username = imageRequest.Username,
                Photo = imageBytes
            };
        }
    }
}
