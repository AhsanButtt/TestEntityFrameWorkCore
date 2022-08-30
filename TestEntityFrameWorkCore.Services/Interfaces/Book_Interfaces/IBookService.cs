using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Models.Models;
using TestEntityFrameWorkCore.Models.ViewModels;

namespace TestEntityFrameWorkCore.Services.Interfaces.Book_Interfaces
{
    public interface IBookService
    {

        void CreateBook(BookViewModel bvm);
        List<Book> ReadAllBooks();
        Book ReadBookById(int Id);
        Book UpdateBookById(int Id, BookViewModel bvm);
        void DeleteBookById(int Id);

        BookVMAuthorPublisher ReadBookAuthorPublishers(int Id);
    }
}
