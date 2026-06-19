using System;
using System.Linq;
using LibraryManagement.Data;

namespace LibraryManagement.Queries
{
    public static class LinqQueries
    {
        // 1. Filter books by author
        public static void FilterByAuthor(string authorName)
        {
            var books = InMemoryStore.Books
                .Where(b => b.Author.Name == authorName);

            Console.WriteLine($"\nBooks by {authorName}:");

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }

        // 2. Select titles sorted alphabetically
        public static void SelectTitlesSorted()
        {
            var titles = InMemoryStore.Books
                .Select(b => b.Title)
                .OrderBy(t => t);

            Console.WriteLine("\nSorted Titles:");

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        // 3. Group books by author
        public static void GroupByAuthor()
        {
            var groups = InMemoryStore.Books
                .GroupBy(b => b.Author.Name);

            Console.WriteLine("\nBooks Grouped By Author:");

            foreach (var group in groups)
            {
                Console.WriteLine($"\nAuthor: {group.Key}");

                foreach (var book in group)
                {
                    Console.WriteLine($" - {book.Title}");
                }
            }
        }

        // 4. Average page count
        public static void AveragePages()
        {
            double average = InMemoryStore.Books
                .Average(b => b.PageCount);

            Console.WriteLine($"\nAverage Pages: {average:F2}");
        }

        // 5. Any book greater than 500 pages
        public static void AnyBookOver500Pages()
        {
            bool exists = InMemoryStore.Books
                .Any(b => b.PageCount > 500);

            Console.WriteLine($"\nAny book over 500 pages? {exists}");
        }

        // 6. FirstOrDefault by Id
        public static void FindBookById(int id)
        {
            var book = InMemoryStore.Books
                .FirstOrDefault(b => b.Id == id);

            Console.WriteLine($"\nBook Search (ID={id})");

            if (book != null)
            {
                Console.WriteLine(book.Title);
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }

        // 7. Join Books and Authors
        public static void JoinBooksAndAuthors()
        {
            var result = InMemoryStore.Books.Join(
                InMemoryStore.Authors,
                book => book.AuthorId,
                author => author.Id,
                (book, author) => new
                {
                    BookTitle = book.Title,
                    AuthorName = author.Name
                });

            Console.WriteLine("\nBooks with Authors:");

            foreach (var item in result)
            {
                Console.WriteLine($"{item.BookTitle} - {item.AuthorName}");
            }
        }

        // 8. Top 3 longest books
        public static void Top3LongestBooks()
        {
            var books = InMemoryStore.Books
                .OrderByDescending(b => b.PageCount)
                .Take(3);

            Console.WriteLine("\nTop 3 Longest Books:");

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.PageCount} pages)");
            }
        }
    }
}