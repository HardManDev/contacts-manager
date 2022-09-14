using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Application.Requests.Contacts.Queries.GetContactList;

public class GetContactListQueryHandler
    : BaseHandler, IRequestHandler<GetContactListQuery, IList<ContactVm>>
{
    public GetContactListQueryHandler(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    public async Task<IList<ContactVm>> Handle(GetContactListQuery request,
        CancellationToken cancellationToken)
    {
        var contacts =
            await DbContext.Contacts
                .Skip(request.Offset ?? 0)
                .Take(request.Count ?? 100)
                .ToListAsync(cancellationToken);

        return Mapper.Map<IList<ContactVm>>(contacts);
    }
}