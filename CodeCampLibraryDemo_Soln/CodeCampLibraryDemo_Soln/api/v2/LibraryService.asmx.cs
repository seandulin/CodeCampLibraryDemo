using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CodeCampLibraryDemo_Soln.Data;
using CodeCampLibraryDemo_Soln.Models;

namespace CodeCampLibraryDemo_Soln
{
    /// <summary>
    /// Summary description for LibraryService1
    /// </summary>
    [WebService(Namespace = "http://library.generalmills.com/v2")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LibraryService1 : System.Web.Services.WebService
    {
        private readonly BookRepository _repository;
        public LibraryService1()
        {
            _repository = new BookRepository();
        }

        [WebMethod]
        public List<Book> GetBooks()
        {
            return _repository.GetBooks().ToList();
        }

        [WebMethod]
        public Book GetBook(string isbn)
        {
            return _repository.GetBook(isbn);
        }

        [WebMethod]
        public Book Checkout(string isbn)
        {
            var book = _repository.GetBook(isbn);
            _repository.Checkout(book);
            return book;
        }
    }
}
