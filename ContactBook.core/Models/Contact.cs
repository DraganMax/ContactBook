using ContactBook.core.Models;
using ContactBookService.core.Models;
using ContactBookService.data.Interfaces;
using ContactBookService.data.Models;
using System;
using System.Collections.Generic;
namespace ContactBook.data.Models
{
    public class Contact : Entity
    {
        public Contact()
        {
            Phones = new List<ContactPhone>();
            Emails = new List<ContactEmail>();
            Addresses = new List<ContactAddress>();
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Company { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<ContactAddress> Addresses { get; set; }

        public virtual ICollection<ContactPhone> Phones { get; set; }

        public virtual ICollection<ContactEmail> Emails { get; set; }
    }
}