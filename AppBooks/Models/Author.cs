﻿using System.Collections.ObjectModel;

namespace AppBooks.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new Collection<Book>();
        }
    }
}
