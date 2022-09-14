using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Domain.Entities;
using ContactsManager.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Tests.Requests;

public class BaseTestsHandler
{
    protected readonly IApplicationDbContext DbContext;
    protected readonly IMapper Mapper;

    public BaseTestsHandler(IMapper mapper, IApplicationDbContext dbContext)
    {
        Mapper = mapper;
        DbContext = dbContext;

        ((DbContext)DbContext).Database.EnsureCreated();
        DbContext.Contacts.AddRange(new List<Contact>
        {
            FixtureContacts.ContactForDelete,
            FixtureContacts.ContactForUpdate,
            FixtureContacts.ContactForGetById
        });
        ((DbContext)DbContext).SaveChanges();
    }
}