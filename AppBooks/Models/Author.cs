using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AppBooks.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        public string? Country { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new Collection<Book>();
        }
    }
}
