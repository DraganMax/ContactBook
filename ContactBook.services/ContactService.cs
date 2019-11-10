using ContactBook.core.Services;
using ContactBook.data.Models;
using ContactBookService.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.services
{
    public class ContactService : EntityService<Contact>, IContactService
    {
        public ContactService(IContactDbContext context) : base(context)
        {

        }
        public async Task<ServiceResult> AddContact(Contact contact)
        {
            return Create(contact);
        }
        public Task<ServiceResult> DeleteContactById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetContact()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactById()
        {
            throw new NotImplementedException();
        }
       
    }
}
