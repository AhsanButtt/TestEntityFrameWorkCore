using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Models.Models;
using TestEntityFrameWorkCore.Models.ViewModels;

namespace TestEntityFrameWorkCore.Services.Interfaces.Publisher_Interfaces
{
    public interface IPublisherService
    {
        void CreatePublisher(PublisherViewModel pvm);
        List<Publisher> ReadAllPublisher();
        Publisher ReadAuthorById(int Id);
        Publisher UpdatePublisherById(int Id, PublisherViewModel pvm);
        void DeletePublisherById(int Id);



        // Getting Books and Authors Of a Publisher
        PublisherViewModelBooksAuthors GetPublisherData(int Id);
    }
}
