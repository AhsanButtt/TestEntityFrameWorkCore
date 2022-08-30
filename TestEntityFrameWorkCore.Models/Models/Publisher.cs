using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFrameWorkCore.Models.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }


        // Navigational Properties for Book Model
        public List<Book> Books { get; set; }
        
    }
}
