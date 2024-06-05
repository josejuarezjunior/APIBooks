using AppBooks.Models;

namespace AppBooks.Repositories
{
    // This interface is usefull to allow specific methods to BookRepository
    public interface IBookRepository: IRepository<Book>
    {
        IEnumerable<Book> GetBooksByAuthor(int id);
    }
}
