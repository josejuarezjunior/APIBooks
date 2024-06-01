namespace AppBooks.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        void Commit();

    }
}
