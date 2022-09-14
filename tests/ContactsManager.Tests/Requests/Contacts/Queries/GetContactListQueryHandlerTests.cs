using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Models.ViewModels;
using ContactsManager.Application.Requests.Contacts.Queries.GetContactList;
using ContactsManager.Tests.Fixtures;
using Xunit;

namespace ContactsManager.Tests.Requests.Contacts.Queries;

public class GetContactListQueryHandlerTests : BaseTestsHandler
{
    public GetContactListQueryHandlerTests(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    [Fact]
    public async Task GetContactListQueryHandler_Success()
    {
        var handler = new GetContactListQueryHandler(Mapper, DbContext);

        var result = await handler.Handle(
            new GetContactListQuery(), CancellationToken.None);

        Assert.IsType<List<ContactVm>>(result);
        // TODO: This static value.
        Assert.True(result.Count == 3);
    }

    [Fact]
    public async Task GetContactListQueryHandler_SuccessWithCount()
    {
        var handler = new GetContactListQueryHandler(Mapper, DbContext);

        var result = await handler.Handle(
            new GetContactListQuery
            {
                Count = 2
            }, CancellationToken.None);

        Assert.IsType<List<ContactVm>>(result);
        // TODO: This static value.
        Assert.True(result.Count == 2);
    }

    [Fact]
    public async Task GetContactListQueryHandler_SuccessWithOffset()
    {
        var handler = new GetContactListQueryHandler(Mapper, DbContext);

        var result = await handler.Handle(
            new GetContactListQuery
            {
                Offset = 1
            }, CancellationToken.None);

        Assert.IsType<List<ContactVm>>(result);
        // TODO: This static value.
        Assert.True(result.Count == 2);
        // TODO: Crutch!
        Assert.True(result.First().Id == FixtureContacts.ContactForUpdate.Id);
    }

    [Fact]
    public async Task GetContactListQueryHandler_SuccessWithOffsetAndCount()
    {
        var handler = new GetContactListQueryHandler(Mapper, DbContext);

        var result = await handler.Handle(
            new GetContactListQuery
            {
                Count = 1,
                Offset = 1
            }, CancellationToken.None);

        Assert.IsType<List<ContactVm>>(result);
        // TODO: This static value.
        Assert.True(result.Count == 1);
        // TODO: Crutch!
        Assert.True(result.First().Id == FixtureContacts.ContactForUpdate.Id);
    }
}