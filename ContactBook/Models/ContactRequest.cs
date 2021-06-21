using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Models
{
    public class ContactRequest : EntityModel
    {
        public ContactRequest()
        {
            Phones = new List<ContactPhoneRequest>();
            Emails = new List<ContactEmailRequest>();
            Addresses = new List<ContactAddressRequest>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Company { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<ContactPhoneRequest> Phones { get; set; }

        public ICollection<ContactEmailRequest> Emails { get; set; }

        public ICollection<ContactAddressRequest> Addresses { get; set; }
    }
}