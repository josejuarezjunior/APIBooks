using System.Text.Json.Serialization;

namespace AppBooks.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public int PublishYear { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsDeleted { get; set; }
        public int AuthorId { get; set; }
        
        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
