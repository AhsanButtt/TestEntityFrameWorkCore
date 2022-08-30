using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Models.ViewModels;
using TestEntityFrameWorkCore.Services.Implementations.PublisherServices;

namespace TestEntityFrameWorkCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("Add_Publisher")]
        public IActionResult AddPublisher([FromBody] PublisherViewModel pvm)
        {
            _publisherService.CreatePublisher(pvm);
            return Ok();
        }
        [HttpGet("Get_All_Publishers")]
        public IActionResult GetAllPublisher()
        {
            var allPublishers = _publisherService.ReadAllPublisher();
            return Ok(allPublishers);
        }

        [HttpGet("Get_Publisher_By_Id/{Id}")]
        public IActionResult GetPublisherById(int Id)
        {
            var onePublisher = _publisherService.ReadAuthorById(Id);
            return Ok(onePublisher);
        }
        [HttpPut("Update_Publisher_By_Id/{Id}")]
        public IActionResult UpdatePublisher(int Id, [FromBody] PublisherViewModel pvm)
        {
            var updatePublisher = _publisherService.UpdatePublisherById(Id, pvm);
            return Ok(updatePublisher);
        }
        [HttpDelete("Delete_Publisher_By_Id/{Id}")]
        public IActionResult DeletePublisher(int Id)
        {
            _publisherService.DeletePublisherById(Id);
            return Ok();
        }



        //Getting Books and Authors of a Publishers
        [HttpGet("Get_Publisher_Books_And_Authors_BY_Id/{Id}")]
        public IActionResult GetPublisherBooksAuthors(int Id)
        {
            var response = _publisherService.GetPublisherData(Id);
            return Ok(response);
        }




        
    }
}
