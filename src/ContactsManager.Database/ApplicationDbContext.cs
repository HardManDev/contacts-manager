using ContactsManager.Application.Interfaces;
using ContactsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Database;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // TODO: Bad practice!
        Database.EnsureCreated();
    }

    public DbSet<Contact> Contacts { get; set; } = null!;
}