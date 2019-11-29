using ContactBook.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IContactService : IEntityService<Contact>
    {
        Task<ServiceResult> AddContact(Contact contact);
        Task<ServiceResult> UpdateContact(Contact contact);
        Task<IEnumerable<Contact>> SearchContact(string search);
        Task<ServiceResult> DeleteContactById(int id);
        Task DeleteContacts();
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
    }
}
