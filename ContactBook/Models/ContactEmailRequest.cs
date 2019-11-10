using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactBook.Models
{
    public class ContactEmailRequest : EntityModel
    {
        public string Email { get; set; }
        public int ContactId { get; set; }
    }
}