namespace AsmensRegistravimoSistemaI2.Database.Interfaces
{
    public interface IGIRepository
    {
        Guid CreateGI(GeneralInformation gI);
        GeneralInformation? GetGI(Guid id);
    }
}