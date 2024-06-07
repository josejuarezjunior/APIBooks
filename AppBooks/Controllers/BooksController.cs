using AppBooks.Context;
using AppBooks.DTOs;
using AppBooks.DTOs.Mappings;
using AppBooks.Models;
using AppBooks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetAll()
        {
            var books = _unitOfWork.BookRepository.GetAll();

            var booksDTO = books.ToBookDTOList();

            return Ok(booksDTO);
        }

        [HttpGet("{id:int}", Name ="GetBook")]
        public ActionResult<BookDTO> Get(int id)
        {
            var book = _unitOfWork.BookRepository.Get(b => b.BookId == id);

            if (book is null)
            {
                return NotFound();
            }

            var bookDTO = book.ToBookDTO();

            return Ok(bookDTO);
        }

        [HttpGet("Author/{id}")]
        public ActionResult<IEnumerable<BookDTO>> GetBooksByAuthor(int id)
        {
            var books = _unitOfWork.BookRepository.GetBooksByAuthor(id);

            if (books is null)
            {
                return NotFound();
            }

            var booksDTO = books.ToBookDTOList();

            return Ok(booksDTO);
        }

        [HttpPost]
        public ActionResult<BookDTO> Create(BookDTO bookDTO)
        {
            if (bookDTO is null)
            {
                return BadRequest();
            }

            var book = bookDTO.ToBook();

            var createdBook = _unitOfWork.BookRepository.Create(book);
            _unitOfWork.Commit();

            var createdBookDTO = createdBook.ToBookDTO();

            return new CreatedAtRouteResult("GetBook", new { id = createdBookDTO.BookId }, createdBookDTO);
        }

        [HttpPut]
        public ActionResult<BookDTO> Update(int id, BookDTO bookDTO)
        {
            if (id != bookDTO.BookId)
            {
                return BadRequest();
            }

            var book = bookDTO.ToBook();

            var updatedBook = _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Commit();

            var updatedBookDTO = updatedBook.ToBookDTO();

            return Ok(updatedBookDTO);
        }

        [HttpPatch("{id:int}")]
        public ActionResult<BookDTO> Delete(int id)
        {
            var book = _unitOfWork.BookRepository.Get(b => b.BookId == id);

            if(book is null)
            {
                return NotFound($"{nameof(book)} is null");
            }

            book.IsDeleted = true;
            var deletedBook = _unitOfWork.BookRepository.Delete(book);
            _unitOfWork.Commit();

            var deleteBookDTO = deletedBook.ToBookDTO();

            return Ok(deleteBookDTO);
        }
    }
}
