using AppBooks.Models;

namespace AppBooks.DTOs.Mappings
{
    public static class BookDTOMappingExtensions
    {
        public static BookDTO? ToBookDTO(this Book book)
        {
            if (book is null)
            {
                return null;
            }

            return new BookDTO()
            {
                BookId = book.BookId,
                Name = book.Name,
                PublishYear = book.PublishYear,
                RegistrationDate = book.RegistrationDate,
                IsDeleted = book.IsDeleted,
                AuthorId = book.AuthorId
            };
        }

        public static Book? ToBook(this BookDTO bookDTO)
        {
            if (bookDTO is null)
            {
                return null;
            }

            return new Book()
            {
                BookId = bookDTO.BookId,
                Name = bookDTO.Name,
                PublishYear = bookDTO.PublishYear,
                RegistrationDate = bookDTO.RegistrationDate,
                IsDeleted = bookDTO.IsDeleted,
                AuthorId = bookDTO.AuthorId
            };
        }

        public static IEnumerable<BookDTO>? ToBookDTOList(this IEnumerable<Book> books)
        {
            if ( books is null || !books.Any())
            {
                return new List<BookDTO>();
            }

            return books.Select(book => new BookDTO()
            {
                BookId = book.BookId,
                Name = book.Name,
                PublishYear = book.PublishYear,
                RegistrationDate = book.RegistrationDate,
                IsDeleted = book.IsDeleted,
                AuthorId = book.AuthorId
            }).ToList();
        }
    }
}
