using AsmensRegistravimoSistemaI2.Models.ImageControllerModels;
using AsmensRegistravimoSistemaI2.Models.InformationControllerModels;
using System.Reflection;

namespace AsmensRegistravimoSistemaI2.Database.InitialData
{
    public static class GeneralInformationInitialData
    {
        public static List<GeneralInformation> GeneralInfos => new()
        {
            new GeneralInformation

            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FirstName = "Jonas",
                LastName = "Kalnietis",
                UserPIN = 11223344556,
                PhoneNumber = "+37061234567",
                Email = "jonas.kalnietis@email.lt",
                ProfilePhoto = new Image
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Username = "pirmas",
                    Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\25.JPG")
                },
                    UserAddress = new Address
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    UserPIN = 11223344556,
                    Town = "Saulėkalnis",
                    Street = "Žydinčių Pieščių alėja",
                    HouseNumber = "24",
                    ApartmentNumber = 15
                }
            },
            new GeneralInformation
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                FirstName = "Eglė",
                LastName = "Žieduolė",
                UserPIN = 11223344557,
                PhoneNumber = "+37062345678",
                Email = "egle.zieduole@email.lt",
                ProfilePhoto = new Image
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Username = "antras",
                    Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\24.JPG")
                },
                UserAddress = new Address
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    UserPIN = 11223344557,
                    Town = "Uolynėlis",
                    Street = "Kalnų viršūnės gatvė",
                    HouseNumber = "8A",
                    ApartmentNumber = 15
                }
            },
            new GeneralInformation
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                FirstName = "Domas",
                LastName = "Uosis",
                UserPIN = 11223344558,
                PhoneNumber = "+37063456789",
                Email = "domas.uosis@email.lt",
                ProfilePhoto = new Image
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Username = "trecias",
                    Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\23.JPG")
                },
                UserAddress = new Address
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    UserPIN = 11223344558,
                    Town = "Ežerpilis",
                    Street = "Ramybės Šilų prospektas",
                    HouseNumber = "56",
                    ApartmentNumber = 12
                }
            },
            new GeneralInformation
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                FirstName = "Rūta",
                LastName = "Smiltelė",
                UserPIN = 11223344559,
                PhoneNumber = "+37064567890",
                Email = "ruta.smiltele@email.lt",
                ProfilePhoto = new Image
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Username = "ketvirtas",
                    Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\22.JPG")
                },
                UserAddress = new Address
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    UserPIN = 11223344559,
                    Town = "Šiloklėnis",
                    Street = "Šimtamečių Ąžuolų gatvė",
                    HouseNumber = "101",
                    ApartmentNumber = 8
                }
            },
            new GeneralInformation
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                FirstName = "Lukas",
                LastName = "Jurėnas",
                UserPIN = 11223344550,
                PhoneNumber = "+37065678901",
                Email = "lukas.jurenas@email.lt",
                ProfilePhoto = new Image
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Username = "penktas",
                    Photo = File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\Images\\21.JPG")
                },
                UserAddress = new Address
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    UserPIN = 11223344550,
                    Town = "Gintarkrantė",
                    Street = "Pajūrio Saulėlydžio takas",
                    HouseNumber = "7",
                    ApartmentNumber = 5
                }
            }
        };
    }
}
