using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CodeCampLibraryDemo_Soln.Models
{
    [DataContract(Namespace = "http://library.generalmills.com/")]
    public class Book
    {
        [DataMember]
        public string Isbn { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public bool IsCheckedOut { get; set; }
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public Publisher Publisher { get; set; }
        [DataMember]
        public Author Author { get; set; }
    }
}