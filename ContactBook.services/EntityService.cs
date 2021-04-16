using ContactBook.core.Services;
using ContactBookService.data;
using ContactBookService.data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IContactDbContext context) : base(context) { }

        public virtual ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public virtual ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }
        public virtual bool Exists(int id)
        {
            return QueryById(id).Any();
        }
        public virtual IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await GetById<T>(id);
        }
        public virtual IQueryable<T> Query()
        {
            return Query<T>();
        }

        public virtual IQueryable<T> QueryById(int id)
        {
            return Query<T>().Where(t => t.Id == id);
        }
        public virtual ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }
    }
}
