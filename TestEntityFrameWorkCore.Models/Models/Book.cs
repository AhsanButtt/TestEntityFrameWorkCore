using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFrameWorkCore.Models.Models
{
   public class Book
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }


        // Navigational Properties for Publisher Model (One To Many Relationship)
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }


        // Navigational Properties for Book_Author (Many To Many Relationship)
        public List<Book_Author> Book_Authors { get; set; }
    }
}
