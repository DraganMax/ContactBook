using ContactBookService.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IAdressService : IEntityService<ContactAdress>
    {
        Task<ServiceResult> AddAdress(ContactAdress adress);
        Task<ServiceResult> DeleteAdressById(int id);
        Task<ServiceResult> UpdateAdress(ContactAdress adress);
    }
}
