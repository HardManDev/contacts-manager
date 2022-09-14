using AutoMapper;
using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Requests.Contacts.Commands.UpdateContact;
using ContactsManager.Tests.Fixtures;
using Xunit;

namespace ContactsManager.Tests.Requests.Contacts.Commands;

public class UpdateContactCommandHandlerTests : BaseTestsHandler
{
    public UpdateContactCommandHandlerTests(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    [Fact]
    public async Task UpdateContactCommandHandler_Success()
    {
        var handler = new UpdateContactCommandHandler(Mapper, DbContext);

        const string testNewName = "Alyssa Smith";
        const string testNewMobilePhone = "+1234-567-8922";
        var testNewJobTitle = string.Empty;
        DateTimeOffset testNewBirthDate = new DateTime(1989, 10, 12);

        await handler.Handle(
            new UpdateContactCommand
            {
                Id = FixtureContacts.ContactForUpdate.Id,
                Name = testNewName,
                MobilePhone = testNewMobilePhone,
                JobTitle = testNewJobTitle,
                BirthDate = testNewBirthDate
            }, CancellationToken.None);

        Assert.NotNull(DbContext.Contacts
            .FirstOrDefault(contact =>
                contact.Id == FixtureContacts.ContactForUpdate.Id &&
                contact.Name == testNewName &&
                contact.MobilePhone == testNewMobilePhone &&
                contact.JobTitle == testNewJobTitle &&
                contact.BirthDate == testNewBirthDate &&
                contact.CreatedAt.Minute == DateTimeOffset.Now.Minute &&
                contact.UpdatedAt!.Value.Minute == DateTimeOffset.Now.Minute));
    }

    [Fact]
    public async Task UpdateContactCommandHandler_FailedOnWrongId()
    {
        var handler = new UpdateContactCommandHandler(Mapper, DbContext);

        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(
                new UpdateContactCommand
                {
                    Id = Guid.Empty
                }, CancellationToken.None);
        });
    }
}