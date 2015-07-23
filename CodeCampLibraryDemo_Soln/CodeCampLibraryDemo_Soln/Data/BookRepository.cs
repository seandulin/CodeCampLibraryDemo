using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCampLibraryDemo_Soln.Models;

namespace CodeCampLibraryDemo_Soln.Data
{
    public class BookRepository
    {
        public static readonly IList<Book> Books = new List<Book>()
        {
            new Book() { Title = "Designing Evolvable Web APIs with ASP.NET", Isbn = "1449337716", IsCheckedOut = false, Price = 30.10, PublishDate = new DateTime(2014, 4, 7), Publisher = new Publisher("O'Reilly"), Author = new Author("Glenn", "Block") },
            new Book() { Title = "Pro ASP.NET Web API Security: Securing ASP.NET Web API", Isbn = "1430257822", IsCheckedOut = false, Price = 18.84, PublishDate = new DateTime(2013, 3, 26), Publisher = new Publisher("Apress"), Author = new Author("Badrinarayanan", "Lakshmiraghavan") },
            new Book() { Title = "ASP.NET Web API 2: Building a REST Service from Start to Finish", Isbn = "1484201108", IsCheckedOut = true, Price = 22.14, PublishDate = new DateTime(2014, 7, 27), Publisher = new Publisher("Apress"), Author = new Author("Jamie", "Kurtz") }
        };
        public IEnumerable<Book> GetBooks()
        {
            return Books.ToList();
        }

        public Book GetBook(string isbn)
        {
            return Books.FirstOrDefault(b => b.Isbn == isbn);
        }

        public void Checkout(Book book)
        {
            if (book == null) throw new ArgumentNullException("book");
            if (book.IsCheckedOut) throw new ApplicationException("Cannot check out book that is already checked out");
            book.IsCheckedOut = true;
        }

        public void Save()
        {
            
        }
    }
}