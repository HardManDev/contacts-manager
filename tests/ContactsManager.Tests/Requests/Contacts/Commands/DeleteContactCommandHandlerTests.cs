using AutoMapper;
using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Requests.Contacts.Commands.DeleteContact;
using ContactsManager.Tests.Fixtures;
using Xunit;

namespace ContactsManager.Tests.Requests.Contacts.Commands;

public class DeleteContactCommandHandlerTests : BaseTestsHandler
{
    public DeleteContactCommandHandlerTests(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    [Fact]
    public async Task DeleteContactCommandHandler_Success()
    {
        var handler = new DeleteContactCommandHandler(Mapper, DbContext);

        await handler.Handle(
            new DeleteContactCommand
            {
                Id = FixtureContacts.ContactForDelete.Id
            }, CancellationToken.None);

        Assert.Null(DbContext.Contacts
            .FirstOrDefault(contact =>
                contact.Id == FixtureContacts.ContactForDelete.Id));
    }

    [Fact]
    public async Task DeleteContactCommandHandler_FailedOnWrongId()
    {
        var handler = new DeleteContactCommandHandler(Mapper, DbContext);

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(
                new DeleteContactCommand
                {
                    Id = Guid.Empty
                }, CancellationToken.None);
        });
    }
}