using ContactBook.core.Models;
using ContactBook.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IEmailService : IEntityService<ContactEmail>
    {
        Task<ServiceResult> AddEmail(ContactEmail email);
        Task<ServiceResult> DeleteEmailById(int id);
        Task<ServiceResult> UpdateEmail(ContactEmail email);
    }
}
