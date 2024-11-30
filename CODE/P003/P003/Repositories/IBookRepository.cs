using P003.DTO;
using P003.Models;

namespace P003.Repositories
{
    public interface IBookRepository
    {
        void Delete(int id);
        List<Book> GetAll();
        Book? GetBookById(int id);
        void Post(Book newBook);
        void Put(Book updatedBook, int id);
    }
}