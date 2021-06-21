using ContactBook.core.Models;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IEmailService : IEntityService<ContactEmail>
    {
        ServiceResult AddEmail(ContactEmail email);

        Task<ServiceResult> DeleteEmailById(int id);

        Task<ServiceResult> UpdateEmail(ContactEmail email);
    }
}
