using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class ContactAdressRequest : EntityModel
    {
        public int ContactId { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string City { get; set; }
    }
}