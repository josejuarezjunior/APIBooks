using System.ComponentModel.DataAnnotations;

namespace AppBooks.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        public int PublishYear { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
