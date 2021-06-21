using ContactBook.core.Models;
using ContactBook.data.Models;
using ContactBookService.core.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace ContactBookService.data
{
    public interface IContactDbContext
    {
        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
 
        DbSet<Contact> Contacts { get; set; }
        
        DbSet<ContactPhone> Phones { get; set; }
        
        DbSet<ContactEmail> Emails { get; set; }
        
        DbSet<ContactAddress> Addresses { get; set; }
        
        int SaveChanges();
        
        Task<int> SaveChangesAsync();
    }
}
