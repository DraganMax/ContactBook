using ContactBook.core.Services;
using ContactBookService.core.Models;
using ContactBookService.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.services
{
    public class AdressService : EntityService<ContactAdress>, IAdressService
    {
        public AdressService(IContactDbContext context) : base(context)
        {

        }

        public async Task<ServiceResult> AddAdress(ContactAdress adress)
        {
            return Create(adress);
        }
        public async Task<ServiceResult> DeleteAdressById(int id)
        {
            var adress = await GetById(id);
            return adress == null ? new ServiceResult(true) : Delete(adress);
        }
        public async Task<ServiceResult> UpdateAdress(ContactAdress adress)
        {
            var updated = await GetById(adress.Id);
            updated.City = adress.City;
            updated.Street = adress.Street;
            updated.House = adress.House;
            return adress == null ? new ServiceResult(true) : Update(updated);
        }
    }
}
