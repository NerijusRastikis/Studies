using Microsoft.Extensions.Logging;
using RestoranasPOS.Repositories;
using RestoranasPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Interfaces
{
    public interface IMenuRepository
    {
        MenuRepository Create(MenuRepository menu);
        MenuRepository Update(MenuRepository menu);
        MenuRepository GetById(int id);
        IEnumerable<MenuRepository> GetAll();
        void Delete(int id);
    }
}
