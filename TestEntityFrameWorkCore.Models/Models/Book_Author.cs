using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFrameWorkCore.Models.Models
{
    public class Book_Author
    {
        public int Id { get; set; }


       // navagational Properties for Book Model
       public int BookId { get; set; }
       public Book Book { get; set; }


        // navigational Properties for Author Model
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
