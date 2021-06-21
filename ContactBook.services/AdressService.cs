using ContactBook.core.Services;
using ContactBookService.core.Models;
using ContactBookService.data;
using System.Threading.Tasks;

namespace ContactBook.services
{
    public class AdressService : EntityService<ContactAddress>, IAdressService
    {
        public AdressService(IContactDbContext context) : base(context)
        { }

        public ServiceResult AddAdress(ContactAddress adress)
        {
            return Create(adress);
        }

        public async Task<ServiceResult> DeleteAdressById(int id)
        {
            var adress = await GetById(id);
            return adress == null ? new ServiceResult(true) : Delete(adress);
        }

        public async Task<ServiceResult> UpdateAdress(ContactAddress adress)
        {
            var updated = await GetById(adress.Id);
            updated.City = adress.City;
            updated.Street = adress.Street;
            return adress == null ? new ServiceResult(true) : Update(updated);
        }
    }
}
