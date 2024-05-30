using AppBooks.Context;
using AppBooks.Models;

namespace AppBooks.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        // This class is usefull to implement specific methods to AuthorRepository
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
