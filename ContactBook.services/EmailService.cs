using ContactBook.core.Models;
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
    public class EmailService : EntityService<ContactEmail>, IEmailService
    {
        public EmailService(IContactDbContext context) : base(context)
        { }

        public ServiceResult AddEmail(ContactEmail email)
        {
            return Create(email);
        }

        public async Task<ServiceResult> DeleteEmailById(int id)
        {
            var email = await GetById(id);
            return email == null ? new ServiceResult(true) : Delete(email);
        }

        public async Task<ServiceResult> UpdateEmail(ContactEmail email)
        {
            var updated = await GetById(email.Id);
            updated.Email = email.Email;
            return email == null ? new ServiceResult(true) : Update(updated);
        }
    }
}
