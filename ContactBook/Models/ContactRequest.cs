using System;
using System.Collections.Generic;

namespace ContactBook.Models
{
    public class ContactRequest : EntityModel
    {
        public ContactRequest()
        {
            Phones = new List<ContactPhoneRequest>();
            Emails = new List<ContactEmailRequest>();
            Adresses = new List<ContactAdressRequest>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<ContactPhoneRequest> Phones { get; set; }
        public ICollection<ContactEmailRequest> Emails { get; set; }
        public ICollection<ContactAdressRequest> Adresses { get; set; }

    }
}