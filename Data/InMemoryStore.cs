using System.Collections.Generic;
using LibraryManagement.Models;

namespace LibraryManagement.Data
{
    public static class InMemoryStore
    {
        // Authors
        public static List<Author> Authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "Robert C. Martin"
            },

            new Author
            {
                Id = 2,
                Name = "Martin Fowler"
            },

            new Author
            {
                Id = 3,
                Name = "Andrew Hunt"
            }
        };

        // Books
        public static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Year = 2008,
                PageCount = 464,
                AuthorId = 1
            },

            new Book
            {
                Id = 2,
                Title = "Clean Architecture",
                Year = 2017,
                PageCount = 432,
                AuthorId = 1
            },

            new Book
            {
                Id = 3,
                Title = "Clean Agile",
                Year = 2019,
                PageCount = 256,
                AuthorId = 1
            },

            new Book
            {
                Id = 4,
                Title = "Refactoring",
                Year = 2018,
                PageCount = 448,
                AuthorId = 2
            },

            new Book
            {
                Id = 5,
                Title = "Patterns of Enterprise Application Architecture",
                Year = 2002,
                PageCount = 560,
                AuthorId = 2
            },

            new Book
            {
                Id = 6,
                Title = "UML Distilled",
                Year = 2003,
                PageCount = 208,
                AuthorId = 2
            },

            new Book
            {
                Id = 7,
                Title = "The Pragmatic Programmer",
                Year = 1999,
                PageCount = 352,
                AuthorId = 3
            },

            new Book
            {
                Id = 8,
                Title = "Pragmatic Thinking and Learning",
                Year = 2008,
                PageCount = 288,
                AuthorId = 3
            }
        };

        // Tags
        public static List<Tag> Tags = new List<Tag>
        {
            new Tag
            {
                Id = 1,
                Name = "Programming"
            },

            new Tag
            {
                Id = 2,
                Name = "Architecture"
            },

            new Tag
            {
                Id = 3,
                Name = "Design"
            },

            new Tag
            {
                Id = 4,
                Name = "Agile"
            }
        };

        // Many-to-Many Links
        public static List<BookTag> BookTags = new List<BookTag>
        {
            new BookTag { BookId = 1, TagId = 1 },
            new BookTag { BookId = 1, TagId = 3 },

            new BookTag { BookId = 2, TagId = 2 },

            new BookTag { BookId = 3, TagId = 4 },

            new BookTag { BookId = 4, TagId = 3 },

            new BookTag { BookId = 7, TagId = 1 }
        };

        // Static Constructor
        static InMemoryStore()
        {
            foreach (var book in Books)
            {
                book.Author = Authors.Find(a => a.Id == book.AuthorId);
            }

            foreach (var author in Authors)
            {
                author.Books = Books
                    .FindAll(b => b.AuthorId == author.Id);
            }
        }
    }
}