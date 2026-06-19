using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        // GET ALL
        public List<Book> GetAll()
        {
            return InMemoryStore.Books;
        }

        // GET BY ID
        public Book GetById(int id)
        {
            return InMemoryStore.Books.FirstOrDefault(b => b.Id == id);
        }

        // CREATE
        public void Create(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            // Generate new ID
            int newId = InMemoryStore.Books.Max(b => b.Id) + 1;
            book.Id = newId;

            // Attach author navigation
            book.Author = InMemoryStore.Authors.FirstOrDefault(a => a.Id == book.AuthorId);

            InMemoryStore.Books.Add(book);

            // Keep Author -> Books relation updated
            if (book.Author != null)
            {
                book.Author.Books.Add(book);
            }
        }

        // UPDATE
        public void Update(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            var existing = InMemoryStore.Books
                .FirstOrDefault(b => b.Id == book.Id);

            if (existing == null)
                return;

            existing.Title = book.Title;
            existing.Year = book.Year;
            existing.PageCount = book.PageCount;
            existing.AuthorId = book.AuthorId;

            // Re-link author
            existing.Author = InMemoryStore.Authors.FirstOrDefault(a => a.Id == book.AuthorId);
        }

        // DELETE
        public void Delete(int id)
        {
            var book = InMemoryStore.Books
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
                return;

            // Remove from author's collection too
            if (book.Author != null)
            {
                book.Author.Books.Remove(book);
            }

            InMemoryStore.Books.Remove(book);
        }
    }
}