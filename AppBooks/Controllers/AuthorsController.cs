using AppBooks.Context;
using AppBooks.Models;
using AppBooks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll();

            if (authors is null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        [HttpGet("{id:int}", Name="GetAuthor")]
        public ActionResult<Author> Get(int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(a => a.AuthorId == id);

            if(author is null) 
            { 
                return NotFound();
            }

            return author;
        }

        [HttpPost]
        public ActionResult<Author> Create(Author author)
        {
            if(author is null)
            {
                return BadRequest();
            }

            var createdAuthor = _unitOfWork.AuthorRepository.Create(author);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("GetAuthor", new { id = createdAuthor.AuthorId }, createdAuthor);
        }

        [HttpPut]
        public ActionResult<Author> Update(int id, Author author)
        {
            if(id != author.AuthorId)
            {
                return BadRequest();
            }

            var updatedAuthor = _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.Commit();

            return Ok(updatedAuthor);
        }

        [HttpPatch("{id:int}")]
        public ActionResult Delete(int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(a => a.AuthorId == id);

            if (author is null)
            {
                return NotFound($"{nameof(author)} is null");
            }

            author.IsDeleted = true;
            var deletedAuthor = _unitOfWork.AuthorRepository.Delete(author);
            _unitOfWork.Commit();

            return Ok(deletedAuthor);
        }
    }
}
