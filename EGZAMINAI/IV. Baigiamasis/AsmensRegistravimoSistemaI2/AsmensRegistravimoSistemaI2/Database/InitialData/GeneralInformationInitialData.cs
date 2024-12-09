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
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        ProfilePhotoId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
        UserAddressId = Guid.Parse("00000000-0000-0000-0000-000000000001") // Set the foreign key here
    },
    new GeneralInformation
    {
        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
        FirstName = "Eglė",
        LastName = "Žieduolė",
        UserPIN = 11223344557,
        PhoneNumber = "+37062345678",
        Email = "egle.zieduole@email.lt",
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
        ProfilePhotoId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
        UserAddressId = Guid.Parse("00000000-0000-0000-0000-000000000002") // Set the foreign key here
    },
    new GeneralInformation
    {
        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
        FirstName = "Domas",
        LastName = "Uosis",
        UserPIN = 11223344558,
        PhoneNumber = "+37063456789",
        Email = "domas.uosis@email.lt",
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
        ProfilePhotoId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
        UserAddressId = Guid.Parse("00000000-0000-0000-0000-000000000003") // Set the foreign key here
    },
    new GeneralInformation
    {
        Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
        FirstName = "Rūta",
        LastName = "Smiltelė",
        UserPIN = 11223344559,
        PhoneNumber = "+37064567890",
        Email = "ruta.smiltele@email.lt",
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
        ProfilePhotoId = Guid.Parse("00000000-0000-0000-0000-000000000004"),
        UserAddressId = Guid.Parse("00000000-0000-0000-0000-000000000004") // Set the foreign key here
    },
    new GeneralInformation
    {
        Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
        FirstName = "Lukas",
        LastName = "Jurėnas",
        UserPIN = 11223344550,
        PhoneNumber = "+37065678901",
        Email = "lukas.jurenas@email.lt",
        UserId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
        ProfilePhotoId = Guid.Parse("00000000-0000-0000-0000-000000000005"),
        UserAddressId = Guid.Parse("00000000-0000-0000-0000-000000000005") // Set the foreign key here
    }
};

    }
}
