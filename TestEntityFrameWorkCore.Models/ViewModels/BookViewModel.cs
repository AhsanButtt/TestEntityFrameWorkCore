using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFrameWorkCore.Models.ViewModels
{
    public class BookViewModel
    {
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }



        //22. Adding Relational Data to DB with Entity Framework Core
        public int PublisherId { get; set; }
        public List<int> AuthorsIds { get; set; }
    }
}
