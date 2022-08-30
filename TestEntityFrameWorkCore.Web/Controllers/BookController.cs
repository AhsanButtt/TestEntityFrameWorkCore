using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Models.ViewModels;
using TestEntityFrameWorkCore.Services.Implementations.BookServices;
using TestEntityFrameWorkCore.Services.Interfaces.Book_Interfaces;

namespace TestEntityFrameWorkCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost("Add_Book")]
        public IActionResult AddBook([FromBody] BookViewModel bvm)
        {
            _bookService.CreateBook(bvm);
            return Ok();
        }

        [HttpGet("Get_All_Books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.ReadAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("Get_Book_By_Id /{Id}")]
        public IActionResult GetBookById(int Id)
        {
            var oneBook = _bookService.ReadBookById(Id);
            return Ok(oneBook);
        }

        [HttpPut("Update_Book/{Id}")]
        public IActionResult UpdateBookById(int Id, [FromBody] BookViewModel bvm)
        {
            var oneBook = _bookService.UpdateBookById(Id,bvm);
            return Ok(oneBook);
        }

        [HttpDelete("Delete_Book_By_Id/{Id}")]
        public IActionResult DeleteBook(int Id)
        {
            _bookService.DeleteBookById(Id);
            return Ok();
        }



        [HttpGet("Get_Book_Author_Publishers")]
        public IActionResult GetBookAuthorPublishers(int Id)
        {
            var oneBook = _bookService.ReadBookAuthorPublishers(Id);
            return Ok(oneBook);
        }
       
    }
}
