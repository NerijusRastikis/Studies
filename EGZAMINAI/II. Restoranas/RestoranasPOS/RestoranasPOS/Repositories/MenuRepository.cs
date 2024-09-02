using Microsoft.Extensions.Logging;
using RestoranasPOS.Interfaces;
using RestoranasPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Repositories
{
    public class MenuRepository : IMenuRepository
    {

        private readonly MenuContext _context;

        public MenuRepository(MenuContext context)
        {
            _context = context;
        }

        public MenuRepository Create(MenuRepository menu)
        {
            _context.menus.Add(menu);
            _context.SaveChanges();

            return menu;
        }

        public void Delete(int id)
        {
            var men = _context.menus.Find(id);
            if (men != null)
            {
                _context.menus.Remove(men);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MenuRepository> GetAll()
        {
            return _context.menus;
        }

        public MenuRepository GetById(int id)
        {
            throw new NotImplementedException();
            //return _context.menus.Include(x => x.  ?  ).FirstOrDefault(x => x.ID == id);
            //return _context.Events.Include(x => x.Performer).FirstOrDefault(x => x.Id == id);

        }

        public MenuRepository Update(MenuRepository menu)
        {
            _context.menus.Update(menu);
            _context.SaveChanges();
            return menu;
        }
    }
}
