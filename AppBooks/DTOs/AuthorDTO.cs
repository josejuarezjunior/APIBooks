using System.ComponentModel.DataAnnotations;

namespace AppBooks.DTOs
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        public string? Country { get; set; }
        public bool IsDeleted { get; set; }
    }
}
