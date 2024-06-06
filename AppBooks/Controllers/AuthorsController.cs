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
    public class AuthorsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> Get()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll();

            if (authors is null)
            {
                return NotFound();
            }

            // Using extension method with DTO
            var authorsDTO = authors.ToAuthorDTOList();

            return Ok(authorsDTO);
        }

        [HttpGet("{id:int}", Name="GetAuthor")]
        public ActionResult<AuthorDTO> Get(int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(a => a.AuthorId == id);

            if(author is null) 
            { 
                return NotFound($"Author with id {id} not found.");
            }

            // Using extension method with DTO
            var authorDTO = author.ToAuthorDTO();

            return authorDTO;
        }

        [HttpPost]
        public ActionResult<AuthorDTO> Create(AuthorDTO authorDTO)
        {
            if(authorDTO is null)
            {
                return BadRequest();
            }

            // Using extension method with DTO
            var author = authorDTO.ToAuthor();

            var createdAuthor = _unitOfWork.AuthorRepository.Create(author);
            _unitOfWork.Commit();

            // Using extension method with DTO
            var createdAuthorDTO = author.ToAuthorDTO();

            return new CreatedAtRouteResult("GetAuthor", new { id = createdAuthorDTO.AuthorId }, createdAuthorDTO);
        }

        [HttpPut]
        public ActionResult<AuthorDTO> Update(int id, AuthorDTO authorDTO)
        {
            if(id != authorDTO.AuthorId)
            {
                return BadRequest();
            }

            // Using extension method with DTO
            var author = authorDTO.ToAuthor();

            var updatedAuthor = _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.Commit();

            // Using extension method with DTO
            var updatedAuthorDTO = updatedAuthor.ToAuthorDTO();

            return Ok(updatedAuthorDTO);
        }

        [HttpPatch("{id:int}")]
        public ActionResult<AuthorDTO> Delete(int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(a => a.AuthorId == id);

            if (author is null)
            {
                return NotFound($"{nameof(author)} is null");
            }

            author.IsDeleted = true;
            var deletedAuthor = _unitOfWork.AuthorRepository.Delete(author);
            _unitOfWork.Commit();

            // Using extension method with DTO
            var detetedAuhtorDTO = deletedAuthor.ToAuthorDTO();

            return Ok(detetedAuhtorDTO);
        }
    }
}
