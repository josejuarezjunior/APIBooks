using AppBooks.Models;

namespace AppBooks.DTOs.Mappings
{
    public static class AuthorDTOMappingExtensions
    {
        public static AuthorDTO? ToAuthorDTO(this Author author)
        {
            if (author is null)
            {
                return null;
            }

            return new AuthorDTO()
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Country = author.Country,
                IsDeleted = author.IsDeleted
            };

        }

        public static Author? ToAuthor(this AuthorDTO authorDTO)
        {
            if (authorDTO is null)
            {
                return null;
            }

            return new Author()
            {
                AuthorId = authorDTO.AuthorId,
                Name = authorDTO.Name,
                Country = authorDTO.Country,
                IsDeleted = authorDTO.IsDeleted
            };
        }

        public static IEnumerable<AuthorDTO>? ToAuthorDTOList(this IEnumerable<Author> authors)
        {
            if (authors is null || !authors.Any()) // Is null or list is empty.
            {
                return new List<AuthorDTO>(); // return empty list.
            }

            return authors.Select(author => new AuthorDTO()
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Country = author.Country,
                IsDeleted = author.IsDeleted
            }).ToList();
        }
    }
}
