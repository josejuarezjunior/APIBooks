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
        private readonly IRepository<Author> _repository;

        public AuthorsController(IRepository<Author> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            var authors = _repository.GetAll();

            if (authors is null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        [HttpGet("{id:int}", Name="GetAuthor")]
        public ActionResult<Author> Get(int id)
        {
            var author = _repository.Get(a => a.AuthorId == id);

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

            var createdAuthor = _repository.Create(author);

            return new CreatedAtRouteResult("GetAuthor", new { id = createdAuthor.AuthorId }, createdAuthor);
        }

        [HttpPut]
        public ActionResult<Author> Update(int id, Author author)
        {
            if(id != author.AuthorId)
            {
                return BadRequest();
            }

            var updatedAuthor = _repository.Update(author);

            return Ok(updatedAuthor);
        }

        [HttpPatch("{id:int}")]
        public ActionResult Delete(int id)
        {
            var author = _repository.Get(a => a.AuthorId == id);

            if (author is null)
            {
                return NotFound($"{nameof(author)} is null");
            }

            author.IsDeleted = true;
            var deletedAuthor = _repository.Delete(author);

            return Ok(deletedAuthor);
        }
    }
}
