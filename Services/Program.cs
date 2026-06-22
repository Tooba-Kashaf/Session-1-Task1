using System;
using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBookService bookService = new BookService();

            Console.WriteLine("==================================");
            Console.WriteLine("INITIAL BOOKS");
            Console.WriteLine("==================================");

            DisplayBooks(bookService);

            //---------------------------------------------------
            // GET BY ID
            //---------------------------------------------------

            Console.WriteLine("\nGET BOOK WITH ID = 1");

            var book = bookService.GetById(1);

            if (book != null)
            {
                Console.WriteLine($"{book.Id} - {book.Title}");
            }

            //---------------------------------------------------
            // CREATE
            //---------------------------------------------------

            Console.WriteLine("\nADDING NEW BOOK...");

            var newBook = new Book
            {
                Title = "C# in Depth",
                Year = 2019,
                PageCount = 900,
                AuthorId = 3
            };

            bookService.Create(newBook);

            Console.WriteLine("BOOK ADDED");

            DisplayBooks(bookService);

            //---------------------------------------------------
            // UPDATE
            //---------------------------------------------------

            Console.WriteLine("\nUPDATING BOOK ID = 2");

            var updatedBook = new Book
            {
                Id = 2,
                Title = "Clean Architecture (Updated Edition)",
                Year = 2024,
                PageCount = 500,
                AuthorId = 1
            };

            bookService.Update(updatedBook);

            Console.WriteLine("BOOK UPDATED");

            DisplayBooks(bookService);

            //---------------------------------------------------
            // DELETE
            //---------------------------------------------------

            Console.WriteLine("\nDELETING BOOK ID = 3");

            bookService.Delete(3);

            Console.WriteLine("BOOK DELETED");

            DisplayBooks(bookService);

            Console.WriteLine("\nTESTING COMPLETE");
        }

        static void DisplayBooks(IBookService bookService)
        {
            foreach (var book in bookService.GetAll())
            {
                Console.WriteLine(
                    $"{book.Id} | " +
                    $"{book.Title} | " +
                    $"{book.Year} | " +
                    $"{book.PageCount} pages | " +
                    $"Author: {book.Author?.Name}"
                );
            }
        }
    }
}