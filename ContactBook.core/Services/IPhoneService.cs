using ContactBook.core.Models;
using ContactBook.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IPhoneService : IEntityService<ContactPhone>
    {
        Task<ServiceResult> AddPhone(ContactPhone phone);
        Task<ServiceResult> DeletePhoneById(int id);
        Task<ServiceResult> UpdatePhone(ContactPhone phone);
    }
}
