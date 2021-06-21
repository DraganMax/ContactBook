using ContactBook.data.Models;
using ContactBookService.data.Models;

namespace ContactBook.core.Models
{
    public class ContactEmail : Entity
    {
        public string Email { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
