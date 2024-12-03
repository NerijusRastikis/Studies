using AsmensRegistravimoSistemaI2.Models.InformationControllerModels;

namespace AsmensRegistravimoSistemaI2.Database.InitialData
{
    public static class GeneralInformationInitialData
    {
        public static List<GeneralInformation> GeneralInfos => new()
        {
            new GeneralInformation

            {
                Id = new Guid(),
                FirstName = "Jonas",
                LastName = "Kalnietis",
                UserPIN = 11223344556,
                PhoneNumber = "+37061234567",
                Email = "jonas.kalnietis@email.lt",
                // rytojui, reikia šiek tiek pakeisti gal Image klasę, nes kaip kitaip užpildyti iš karto?
                // nebent naudoti File.ReadAllBytes($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\InitialData\\sunrise.PNG"),
            }
        };
    }
}
