using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CodeCampLibraryDemo_Soln.Models;

namespace CodeCampLibraryDemo_Soln
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILibraryService" in both code and config file together.
    [ServiceContract(Namespace = "http://library.generalmills.com/v1")]
    public interface ILibraryService
    {
        [OperationContract]
        List<Book> GetBooks();
        [OperationContract]
        Book GetBook(string isbn);
        [OperationContract]
        Book Checkout(string isbn);
    }
}
