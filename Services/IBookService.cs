using System.Collections.Generic;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public interface IBookService
    {
        List<Book> GetAll();

        Book GetById(int id);

        void Create(Book book);

        void Update(Book book);

        void Delete(int id);
    }
}