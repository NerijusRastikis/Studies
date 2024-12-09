using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using System.Reflection;

namespace AsmensRegistravimoSistemaI2.Database.InitialData
{
    public static class ImagesInitialData
    {
        public static List<Image> Images => new()
        {
            new Image
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                Username = "pirmas",
                Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\25.jpg")
            },
            new Image
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                Username = "antras",
                Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\24.jpg")
            },
            new Image
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                Username = "trecias",
                Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\23.jpg")
            },
            new Image
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                Username = "ketvirtas",
                Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\22.jpg")
            },
            new Image
            {
                Id = new Guid("00000000-0000-0000-0000-000000000005"),
                Username = "penktas",
                Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\21.jpg")
            }
        };
    }
}
