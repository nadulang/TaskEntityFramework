using Microsoft.EntityFrameworkCore;
using TaskEntityFramework.Models;


namespace TaskEntityFramework
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options): base(options){ }
        public DbSet<UserContacts> UserContacts { get; set; }
    }

}