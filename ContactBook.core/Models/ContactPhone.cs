using ContactBook.data.Models;
using ContactBookService.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Models
{
    public class ContactPhone : Entity
    {
        public string Number { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
