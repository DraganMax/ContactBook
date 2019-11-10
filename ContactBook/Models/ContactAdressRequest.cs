using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class ContactAdressRequest : EntityModel
    {
        public string Street { get; set; }
        public string House { get; set; }
        public int ContactId { get; set; }
        public string City { get; set; }
        public string Apartment { get; set; }
        public string Region { get; set; }
    }
}