using RestoranasPOS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Interfaces
{
    public interface ITableRepository
    {
        TableRepository Create(TableRepository table);
        TableRepository Update(TableRepository table);
        TableRepository GetById(int id);
        IEnumerable<TableRepository> GetAll();
        void Delete(int id);
    }
}
