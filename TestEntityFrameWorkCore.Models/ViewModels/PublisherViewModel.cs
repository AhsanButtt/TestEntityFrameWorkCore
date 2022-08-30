using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFrameWorkCore.Models.ViewModels
{
    public class PublisherViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }




    // Many To Many Relationships
    // Getting Books and Authors of a Publisher
    public class PublisherViewModelBooksAuthors
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
       
    }


    // Many To Many Relationships
    // Getting Books and Authors of a Publisher
    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
