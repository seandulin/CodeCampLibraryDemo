using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CodeCampLibraryDemo_Soln.Models
{
    [DataContract(Namespace = "http://library.generalmills.com/")]
    public class Publisher
    {
        [DataMember]
        public string CompanyName { get; set; }

        public Publisher()
        {
            
        }

        public Publisher(string companyName)
        {
            CompanyName = companyName;
        }
    }
}