using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEntityFrameWorkCore.Data.Data;
using TestEntityFrameWorkCore.Models.Models;
using TestEntityFrameWorkCore.Models.ViewModels;
using TestEntityFrameWorkCore.Services.Interfaces.Publisher_Interfaces;

namespace TestEntityFrameWorkCore.Services.Implementations.PublisherServices
{
    public class PublisherService : IPublisherService
    {
        public AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePublisher(PublisherViewModel pvm)
        {
            var onePublisher = new Publisher()
            {
                FirstName = pvm.FirstName,
                LastName = pvm.LastName,
                EmailAddress = pvm.EmailAddress,
                PhoneNo = pvm.PhoneNo,
                Address = pvm.Address,
            };
            _context.Publishers.Add(onePublisher);
            _context.SaveChanges();
        }
        public List<Publisher> ReadAllPublisher()
        {
            var allPublishers = _context.Publishers.ToList();
            return allPublishers;
        }
        public Publisher ReadAuthorById(int Id) => _context.Publishers.FirstOrDefault(x => x.Id == Id);



        public Publisher UpdatePublisherById(int Id, PublisherViewModel pvm)
        {
            var updatePublisher = _context.Publishers.FirstOrDefault(x => x.Id == Id);
            if(updatePublisher != null)
            {
                updatePublisher.FirstName = pvm.FirstName;
                updatePublisher.LastName = pvm.LastName;
                updatePublisher.EmailAddress = pvm.EmailAddress;
                updatePublisher.PhoneNo = pvm.PhoneNo;
                updatePublisher.Address = pvm.Address;

                _context.SaveChanges();
            };
            return updatePublisher;
        }
        public void DeletePublisherById(int Id)
        {
            var delPublisher = _context.Publishers.FirstOrDefault(x => x.Id == Id);
            if(delPublisher != null)
            {
                _context.Publishers.Remove(delPublisher);
                _context.SaveChanges();
                    
            }
        }








        // Getting Books and Authors Of A Publisher
        public PublisherViewModelBooksAuthors GetPublisherData(int Id) 
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == Id)
                .Select(n => new PublisherViewModelBooksAuthors()
                {
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.BookTitle,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FirstName).ToList()

                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }
    }
}
