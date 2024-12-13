using AsmensRegistravimoSistemaI2.Database.Interfaces;
using AsmensRegistravimoSistemaI2.DTOs.Results;

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
        public GeneralInformation? GetGIById(Guid id)
        {
            return _context.GeneralInfos.FirstOrDefault(x => x.Id == id);
        }
        public GeneralInformationDTOResult GetGIByIdForClient(Guid id)
        {
            var selectedGI = _context.GeneralInfos.FirstOrDefault(x => x.Id == id);
            var result = new GeneralInformationDTOResult
            {
                FirstName = selectedGI.FirstName,
                LastName = selectedGI.LastName,
                PersonalCode = selectedGI.PersonalCode,
                PhoneNumber = selectedGI.PhoneNumber,
                Email = selectedGI.Email,
                ProfilePhoto = selectedGI.GIImage,
            };
            return result;
        }
        public bool UpdateGI(GeneralInformation gI)
        {
            _context.GeneralInfos.Update(gI);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteGI(Guid id)
        {
            var gI = _context.GeneralInfos.Find(id);
            if (gI is not null)
            {
                _context.GeneralInfos.Remove(gI);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
