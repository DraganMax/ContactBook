using ContactBookService.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core.Services
{
    public interface IEntityService<T> where T : Entity
    {
        IQueryable<T> Query();
        IQueryable<T> QueryById(int id);
        IEnumerable<T> Get();
        Task<T> GetById(int id);
        ServiceResult Create(T entity);
        ServiceResult Update(T entity);
        ServiceResult Delete(T entity);
        bool Exists(int id);
    }
}
