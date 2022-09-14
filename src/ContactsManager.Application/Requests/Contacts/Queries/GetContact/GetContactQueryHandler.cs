using AutoMapper;
using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Models.ViewModels;
using ContactsManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Application.Requests.Contacts.Queries.GetContact;

public class GetContactQueryHandler
    : BaseHandler, IRequestHandler<GetContactQuery, ContactVm>
{
    public GetContactQueryHandler(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    public async Task<ContactVm> Handle(GetContactQuery request,
        CancellationToken cancellationToken)
    {
        var targetContact =
            await DbContext.Contacts
                .FirstOrDefaultAsync(contact => contact.Id == request.Id,
                    cancellationToken)
            ?? throw new NotFoundException(nameof(Contact), request.Id);

        return Mapper.Map<ContactVm>(targetContact);
    }
}