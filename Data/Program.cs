using System;
using LibraryManagement.Data;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== AUTHORS =====");

            foreach (var author in InMemoryStore.Authors)
            {
                Console.WriteLine($"Id: {author.Id}");
                Console.WriteLine($"Name: {author.Name}");

                Console.WriteLine("Books:");

                foreach (var book in author.Books)
                {
                    Console.WriteLine($"  - {book.Title}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n===== BOOKS =====");

            foreach (var book in InMemoryStore.Books)
            {
                Console.WriteLine(
                    $"{book.Title} ({book.Year}) " +
                    $"Pages: {book.PageCount} " +
                    $"Author: {book.Author.Name}");
            }

            Console.WriteLine("\n===== TAGS =====");

            foreach (var tag in InMemoryStore.Tags)
            {
                Console.WriteLine($"{tag.Id} - {tag.Name}");
            }

            Console.WriteLine("\n===== BOOK TAG LINKS =====");

            foreach (var link in InMemoryStore.BookTags)
            {
                Console.WriteLine(
                    $"BookId: {link.BookId} -> TagId: {link.TagId}");
            }
        }
    }
}
