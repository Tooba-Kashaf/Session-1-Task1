namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int PageCount { get; set; }

        public int AuthorId { get; set; }

        // Navigation Property
        public Author Author { get; set; }
    }
}