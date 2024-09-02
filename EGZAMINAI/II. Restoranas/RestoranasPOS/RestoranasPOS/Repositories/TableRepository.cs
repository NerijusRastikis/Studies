using RestoranasPOS.Interfaces;
using RestoranasPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly TableContext _context;

        public TableRepository(TableContext context)
        {
            _context = context;
        }

        public TableRepository Create(TableRepository table)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableRepository> GetAll()
        {
            throw new NotImplementedException();
        }

        public TableRepository GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TableRepository Update(TableRepository table)
        {
            throw new NotImplementedException();
        }
    }
}
