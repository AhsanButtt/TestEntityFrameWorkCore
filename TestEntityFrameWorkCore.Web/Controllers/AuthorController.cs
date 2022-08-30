using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Models.ViewModels;
using TestEntityFrameWorkCore.Services.Implementations.AuthorServices;

namespace TestEntityFrameWorkCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public AuthorService _authorService;
        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }


        [HttpPost("Add_Author")]
        public IActionResult AddAuthor([FromBody] AuthorViewModel avm)
        {
            _authorService.CreateAuthor(avm);
            return Ok();
        }
        [HttpGet("Get_All_Authors")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorService.ReadAllAuthors();
            return Ok(allAuthors);
        }
        [HttpGet("Get_Author_By_Id/{Id}")]
        public IActionResult GetAuthorById(int Id)
        {
            var oneAuthor = _authorService.ReadAuthorById(Id);
            return Ok(oneAuthor);
        }
        
       [HttpPut("Update_Author_By_Id/{Id}")]
       public IActionResult UpdateAuthorById(int Id, AuthorViewModel avm)
        {
            var updateAuthor = _authorService.UpdateAuthorById(Id, avm);
            return Ok(updateAuthor);
        }
        [HttpDelete("Delete_Author_By_Id/{Id}")]
        public IActionResult DeleteAuthor(int Id)
        {
            _authorService.DeleteAuthorById(Id);
            return Ok();
        }


        // Getting Books Of Author
        [HttpGet("Get_Books_Of_Author_By_Id/{Id}")]
        public IActionResult GetBooksOfAuthorById(int Id)
        {
            var oneAuthor =_authorService.ReadAuthorBooks(Id);
            return Ok(oneAuthor);
        }

        
    }
}
