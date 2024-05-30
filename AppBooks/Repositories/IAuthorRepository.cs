using AppBooks.Models;

namespace AppBooks.Repositories
{
    // This interface is usefull to allow specific methods to AuthorRepository
    public interface IAuthorRepository: IRepository<Author>
    {
    }
}
