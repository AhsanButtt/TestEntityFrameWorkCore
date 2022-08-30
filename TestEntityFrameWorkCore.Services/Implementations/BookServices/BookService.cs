using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Data.Data;
using TestEntityFrameWorkCore.Models.Models;
using TestEntityFrameWorkCore.Models.ViewModels;
using TestEntityFrameWorkCore.Services.Interfaces.Book_Interfaces;

namespace TestEntityFrameWorkCore.Services.Implementations.BookServices
{
    public class BookService : IBookService
    {

        public AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        // Add Book Method
        public void CreateBook(BookViewModel bvm)
        {
            var newBook = new Book()
            {
                BookTitle = bvm.BookTitle,
                BookDescription = bvm.BookDescription,
                Genre = bvm.Genre,
                Price = bvm.Price,
                //22. Adding Relational Data to DB with Entity Framework Core
                PublisherId = bvm.PublisherId
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();

            foreach (var id in bvm.AuthorsIds)
            {
                var _book_Author = new Book_Author()
                {
                    BookId = newBook.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_Author);
                _context.SaveChanges();
            }

        }


        // Get All Books Method
        public List<Book> ReadAllBooks()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }

        // Get Book By Id Method
        public Book ReadBookById(int Id) => _context.Books.FirstOrDefault(option => option.Id == Id);




        // Update Book By Id Method
        public Book UpdateBookById(int Id, BookViewModel bvm)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == Id);
            if (_book != null)
            {
                _book.BookTitle = bvm.BookTitle;
                _book.BookDescription = bvm.BookDescription;
                _book.Genre = bvm.Genre;
                _book.Price = bvm.Price;

                _context.SaveChanges();
            }
            return _book;
        }

        // Delete Book By Id Method
        public void DeleteBookById(int Id)
        {
            var delBook = _context.Books.FirstOrDefault(n => n.Id == Id);
            if (delBook != null)
            {
                _context.Books.Remove(delBook);
                _context.SaveChanges();
            }
        }

        public BookVMAuthorPublisher ReadBookAuthorPublishers(int Id)
        {
            var _book = _context.Books.Where(n => n.Id == Id).Select(bvm => new BookVMAuthorPublisher()
            {
                BookTitle = bvm.BookTitle,
                BookDescription = bvm.BookDescription,
                Genre = bvm.Genre,
                Price = bvm.Price,
                //22. Adding Relational Data to DB with Entity Framework Core
                PublisherName = bvm.Publisher.FirstName,
                AuthorNames = bvm.Book_Authors.Select(n => n.Author.FirstName).ToList()

            }).FirstOrDefault();
            return _book;
        }

        
    }
}
