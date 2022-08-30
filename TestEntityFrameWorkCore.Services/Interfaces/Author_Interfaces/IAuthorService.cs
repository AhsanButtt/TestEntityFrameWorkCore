using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Models.Models;
using TestEntityFrameWorkCore.Models.ViewModels;

namespace TestEntityFrameWorkCore.Services.Interfaces.Author_Interfaces
{
    public interface IAuthorService
    {
        void CreateAuthor(AuthorViewModel avm);
        List<Author> ReadAllAuthors();
        Author ReadAuthorById(int Id);
        Author UpdateAuthorById(int Id, AuthorViewModel avm);
        void DeleteAuthorById(int Id);

        AuthorVMBooks ReadAuthorBooks(int Id);
    }
}
