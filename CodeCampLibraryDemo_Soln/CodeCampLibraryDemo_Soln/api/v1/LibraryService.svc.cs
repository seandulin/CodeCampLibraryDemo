using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CodeCampLibraryDemo_Soln.Data;
using CodeCampLibraryDemo_Soln.Models;

namespace CodeCampLibraryDemo_Soln
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LibraryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LibraryService.svc or LibraryService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(Namespace = "http://library.generalmills.com/v1")]
    [BindingNamespaceBehavior("http://library.generalmills.com/v1")]
    public class LibraryService : ILibraryService
    {
         private readonly BookRepository _repository;
         public LibraryService()
        {
            _repository = new BookRepository();
        }

        public List<Book> GetBooks()
        {
            return _repository.GetBooks().ToList();
        }

        public Book GetBook(string isbn)
        {
            return _repository.GetBook(isbn);
        }

        public Book Checkout(string isbn)
        {
            var book = _repository.GetBook(isbn);
            _repository.Checkout(book);
            return book;
        }
    }
}
