using ContactBook.data.Models;
using ContactBookService.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookService.core.Models
{
    public class ContactAdress : Entity
    {
        public string Street { get; set; }
        public string House { get; set; }
        public int ContactId { get; set; }
        public string City { get; set; }
        public string Apartment { get; set; }
        public string Region { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
