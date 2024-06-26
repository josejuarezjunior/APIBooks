﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppBooks.Models
{
    public class Book
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
        
        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
