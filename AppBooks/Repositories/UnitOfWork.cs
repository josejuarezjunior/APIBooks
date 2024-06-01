using AppBooks.Context;

namespace AppBooks.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IBookRepository? _bookRepository;

        private IAuthorRepository? _authorRepository;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        // Lazy loading
        public IBookRepository BookRepository
        {
            get
            {
                //if (_bookRepository == null)
                //{
                //    _bookRepository = new BookRepository(_context);
                //}

                //return _bookRepository;

                return _bookRepository = _bookRepository ?? new BookRepository(_context);
            }
        }

        // Lazy loading
        public IAuthorRepository AuthorRepository
        {
            get
            {
                //if (_authorRepository == null)
                //{
                //    _authorRepository = new AuthorRepository(_context);
                //}

                //return _authorRepository;

                return _authorRepository = _authorRepository ?? new AuthorRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
