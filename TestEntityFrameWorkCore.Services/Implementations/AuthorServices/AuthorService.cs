using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Data.Data;
using TestEntityFrameWorkCore.Models.Models;
using TestEntityFrameWorkCore.Models.ViewModels;
using TestEntityFrameWorkCore.Services.Interfaces.Author_Interfaces;

namespace TestEntityFrameWorkCore.Services.Implementations.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        public AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }


        public void CreateAuthor(AuthorViewModel avm)
        {
            var newAuthor = new Author()
            {
                FirstName = avm.FirstName,
                LastName = avm.LastName,
                EmailAddress = avm.EmailAddress,
            };
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();

        }
        public List<Author> ReadAllAuthors()
        {
            var allAuthors = _context.Authors.ToList();
            return allAuthors;
        }
        public Author ReadAuthorById(int Id) => _context.Authors.FirstOrDefault(n => n.Id == Id);
        
          
        
        public Author UpdateAuthorById(int Id, AuthorViewModel avm)
        {
            var updateAuthor = _context.Authors.FirstOrDefault(n => n.Id == Id);
            if(updateAuthor!=null)
            {
                updateAuthor.FirstName = avm.FirstName;
                updateAuthor.LastName = avm.LastName;
                updateAuthor.EmailAddress = avm.EmailAddress;
                _context.SaveChanges();
            }
            return updateAuthor;
        }
        public void DeleteAuthorById(int Id)
        {
            var delAuthor = _context.Authors.FirstOrDefault(n => n.Id == Id);
            if(delAuthor!= null)
            {
                _context.Authors.Remove(delAuthor);
                _context.SaveChanges();
            }
        }



        // Reading Books of An Author
       public AuthorVMBooks ReadAuthorBooks(int Id)
        {
            var _author = _context.Authors.Where(n => n.Id == Id).Select(n => new AuthorVMBooks()
            {

                FirstName = n.FirstName,
                LastName = n.LastName,
                BookTitles = n.Book_Authors.Select(n => n.Book.BookTitle).ToList()

            }).FirstOrDefault();
            return _author;
        }
    }
}
