using AppBooks.Context;
using AppBooks.Models;

namespace AppBooks.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        // This class is usefull to implement specific methods to BookRepository
        public BookRepository(AppDbContext context) : base(context)
        {

        }

        public IEnumerable<Book> GetBooksByAuthor(int id)
        {
            return GetAll().Where(author => author.AuthorId == id);
        }
    }
}
