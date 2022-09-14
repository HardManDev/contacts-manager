using ContactsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Contact> Contacts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}