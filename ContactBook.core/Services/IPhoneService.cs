using ContactBook.core.Models;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IPhoneService : IEntityService<ContactPhone>
    {
        ServiceResult AddPhone(ContactPhone phone);

        Task<ServiceResult> DeletePhoneById(int id);

        Task<ServiceResult> UpdatePhone(ContactPhone phone);
    }
}
