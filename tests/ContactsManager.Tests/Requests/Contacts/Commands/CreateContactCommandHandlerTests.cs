using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Requests.Contacts.Commands.CreateContact;
using Xunit;

namespace ContactsManager.Tests.Requests.Contacts.Commands;

public class CreateContactCommandHandlerTests : BaseTestsHandler
{
    public CreateContactCommandHandlerTests(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    [Fact]
    public async Task CreateContactCommandHandler_Success()
    {
        var handler = new CreateContactCommandHandler(Mapper, DbContext);

        const string testName = "Leroy Garrison";
        const string testMobilePhone = "+1234-567-8910";
        const string testJobTitle = "This is a new job title!";
        var testBirthDate = new DateTime(1969, 5, 26);

        var result = await handler.Handle(
            new CreateContactCommand
            {
                Name = testName,
                MobilePhone = testMobilePhone,
                JobTitle = testJobTitle,
                BirthDate = testBirthDate
            }, CancellationToken.None);

        Assert.NotNull(DbContext.Contacts
            .FirstOrDefault(contact =>
                contact.Id == result &&
                contact.Name == testName &&
                contact.MobilePhone == testMobilePhone &&
                contact.JobTitle == testJobTitle &&
                contact.BirthDate == testBirthDate &&
                contact.CreatedAt.Minute == DateTimeOffset.Now.Minute &&
                contact.UpdatedAt == null));
    }
}