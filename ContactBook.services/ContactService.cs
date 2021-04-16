using ContactBook.core.Services;
using ContactBook.data.Models;
using ContactBookService.data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<ServiceResult> UpdateContact(Contact contact)
        {
            var updated = await GetById(contact.Id);
            updated.Name = contact.Name;
            updated.Surname = contact.Surname;
            updated.Company = contact.Company;
            updated.Birthday = contact.Birthday;
            foreach(var number in contact.Phones)
            {
                var updatedPhone = updated.Phones.Where(pn => pn.Id == contact.Id).FirstOrDefault();
                if (updatedPhone == null)
                {
                    contact.Phones.Add(number);
                }
                else
                {
                    updatedPhone.Number = number.Number; 
                }
            }
            return contact == null ? new ServiceResult(true) : Update(updated);
        }
        public async Task<ServiceResult> DeleteContactById(int id)
        {
            var contact = await GetById(id);
            return contact == null ? new ServiceResult(true) : Delete(contact);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await Task.FromResult(Get());
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await GetById(id);
        }
        public async Task<IEnumerable<Contact>> SearchContact(string search)
        {
            search = search.ToLower().Trim();
            var contact = Query().Where(c => c.Name.ToLower().Contains(search) ||
                c.Surname.ToLower().Contains(search) ||
                c.Company.ToLower().Contains(search) ||
                c.Emails.Any(a => a.Email.ToLower().Contains(search) ||
                c.Phones.Any(b => b.Number.ToLower().Contains(search))));
            return await contact.ToListAsync();
        }
        public async Task DeleteContacts()
        {
            _ctx.Contacts.RemoveRange(_ctx.Contacts);
            _ctx.Phones.RemoveRange(_ctx.Phones);
            _ctx.Emails.RemoveRange(_ctx.Emails);
            _ctx.Addresses.RemoveRange(_ctx.Addresses);
            await _ctx.SaveChangesAsync();
        }
    }
}
