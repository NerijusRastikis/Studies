using AsmensRegistravimoSistemaI2.Database.Interfaces;

namespace AsmensRegistravimoSistemaI2.Database.Repositories
{
    public class GIRepository : IGIRepository
    {
        private readonly ARSDbContext _context;

        public GIRepository(ARSDbContext context)
        {
            _context = context;
        }
        public Guid CreateGI(GeneralInformation gI)
        {
            _context.GeneralInfos.Add(gI);
            _context.SaveChanges();
            return gI.Id;
        }
        public GeneralInformation? GetGI(Guid id)
        {
            return _context.GeneralInfos.FirstOrDefault(x => x.Id == id);
        }
    }
}
