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
    public class PhoneService : EntityService<ContactPhone>, IPhoneService
    {
        public PhoneService(IContactDbContext context) : base(context)
        {

        }
        public async Task<ServiceResult> AddPhone(ContactPhone phone)
        {
            return Create(phone);
        }
        public async Task<ServiceResult> DeletePhoneById(int id)
        {
            var phone = await GetById(id);
            return phone == null ? new ServiceResult(true) : Delete(phone);
        }
        public async Task<ServiceResult> UpdatePhone(ContactPhone phone)
        {
            var updated = await GetById(phone.Id);
            updated.Number = phone.Number;
            return phone == null ? new ServiceResult(true) : Update(updated);
        }
    }
}
