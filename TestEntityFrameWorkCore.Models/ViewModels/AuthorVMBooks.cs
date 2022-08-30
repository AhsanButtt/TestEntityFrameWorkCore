using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFrameWorkCore.Models.ViewModels
{
    public class AuthorVMBooks
    {
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public List<string>BookTitles { get; set; }
    }
}
