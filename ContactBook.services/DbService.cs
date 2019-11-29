using ContactBook.core.Services;
using ContactBookService.data;
using ContactBookService.data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.services
{
    public class DbService : IDbService
    {
        protected readonly IContactDbContext _ctx;
        public DbService(IContactDbContext context)
        {
            _ctx = context;
        }

        public ServiceResult Create<T>(T entity) where T : Entity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();

            return new ServiceResult(true).Set(entity);
        }

        public ServiceResult Delete<T>(T entity) where T : Entity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
            return new ServiceResult(true);
        }

        public bool Exists<T>(int id) where T : Entity
        {
            return QueryById<T>(id).Any();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return Query<T>().ToList();
        }

        public virtual async Task<T> GetById<T>(int id) where T : Entity
        {
            return await _ctx.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public virtual IQueryable<T> Query<T>() where T : Entity
        {
            return _ctx.Set<T>().AsQueryable();
        }
        public virtual IQueryable<T> QueryById<T>(int id) where T : Entity
        {
            return Query<T>().Where(t => t.Id == id);
        }

        public ServiceResult Update<T>(T entity) where T : Entity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
            return new ServiceResult(true).Set(entity);
        }

    }
}
