using agenda_api.Models;

using Microsoft.EntityFrameworkCore;

namespace agenda_api.Data;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> opts) : base(opts) { }   

    public DbSet<Contact> Contacts { get; set; }
}
