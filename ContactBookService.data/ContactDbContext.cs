using ContactBook.core.Models;
using ContactBook.data.Models;
using ContactBookService.core.Models;
using ContactBookService.data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookService.data
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public ContactDbContext() : base("ContactDbContext")
        {
            Database.Log = Console.WriteLine;
            Database.SetInitializer<ContactDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactDbContext, Configuration>());
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPhone> Phones { get; set; }
        public DbSet<ContactEmail> Emails { get; set; }
        public DbSet<ContactAdress> Addresses { get; set; }
    }
}
