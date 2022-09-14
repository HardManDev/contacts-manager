using AutoMapper;
using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Models.ViewModels;
using ContactsManager.Application.Requests.Contacts.Queries.GetContact;
using ContactsManager.Tests.Fixtures;
using Xunit;

namespace ContactsManager.Tests.Requests.Contacts.Queries;

public class GetContactQueryHandlerTests : BaseTestsHandler
{
    public GetContactQueryHandlerTests(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    [Fact]
    public async Task GetContactQueryHandler_Success()
    {
        var handler = new GetContactQueryHandler(Mapper, DbContext);

        var result = await handler.Handle(
            new GetContactQuery
            {
                Id = FixtureContacts.ContactForGetById.Id
            }, CancellationToken.None);

        Assert.IsType<ContactVm>(result);
        Assert.True(result.Id == FixtureContacts.ContactForGetById.Id &&
                    result.Name == FixtureContacts.ContactForGetById.Name &&
                    result.MobilePhone ==
                    FixtureContacts.ContactForGetById.MobilePhone &&
                    result.JobTitle ==
                    FixtureContacts.ContactForGetById.JobTitle &&
                    result.BirthDate ==
                    FixtureContacts.ContactForGetById.BirthDate &&
                    result.CreatedAt ==
                    FixtureContacts.ContactForGetById.CreatedAt &&
                    result.UpdatedAt ==
                    FixtureContacts.ContactForGetById.UpdatedAt);
    }

    [Fact]
    public async Task GetContactQueryHandler_FailedOnWrongId()
    {
        var handler = new GetContactQueryHandler(Mapper, DbContext);

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(
                new GetContactQuery
                {
                    Id = Guid.Empty
                }, CancellationToken.None);
        });
    }
}