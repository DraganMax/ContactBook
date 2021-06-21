using ContactBookService.core.Models;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IAdressService : IEntityService<ContactAddress>
    {
        ServiceResult AddAdress(ContactAddress adress);

        Task<ServiceResult> DeleteAdressById(int id);

        Task<ServiceResult> UpdateAdress(ContactAddress adress);
    }
}
