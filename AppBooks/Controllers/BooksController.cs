using AppBooks.Context;
using AppBooks.Models;
using AppBooks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController: ControllerBase
    {
        private readonly IRepository<Book> _repository;
        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _repository.GetAll();
            return Ok(books);
        }

        [HttpGet("{id:int}", Name ="GetBook")]
        public ActionResult<Book> Get(int id)
        {
            var book = _repository.Get(b => b.BookId == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create(Book book)
        {
            if (book is null)
            {
                return BadRequest();
            }

            var createdBook = _repository.Create(book);

            return new CreatedAtRouteResult("GetBook", new { id = createdBook.BookId }, createdBook);
        }

        [HttpPut]
        public ActionResult<Book> Update(int id, Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            var updatedBook = _repository.Update(book);

            return Ok(updatedBook);
        }

        [HttpPatch("{id:int}")]
        public ActionResult Delete(int id)
        {
            var book = _repository.Get(b => b.BookId == id);

            if(book is null)
            {
                return NotFound($"{nameof(book)} is null");
            }

            book.IsDeleted = true;
            var deletedBook = _repository.Delete(book);

            return Ok(deletedBook);
        }
    }
}
