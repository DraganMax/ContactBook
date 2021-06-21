using ContactBook.data.Models;
using ContactBookService.data.Models;

namespace ContactBookService.core.Models
{
    public class ContactAddress : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
