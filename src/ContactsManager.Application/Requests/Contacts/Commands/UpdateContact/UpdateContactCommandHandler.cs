using AutoMapper;
using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces;
using ContactsManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Application.Requests.Contacts.Commands.UpdateContact;

public class UpdateContactCommandHandler
    : BaseHandler, IRequestHandler<UpdateContactCommand>
{
    public UpdateContactCommandHandler(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    public async Task<Unit> Handle(UpdateContactCommand request,
        CancellationToken cancellationToken)
    {
        var targetContact =
            await DbContext.Contacts
                .FirstOrDefaultAsync(contact => contact.Id == request.Id,
                    cancellationToken)
            ?? throw new NotFoundException(nameof(Contact), request.Id);

        targetContact.Name = request.Name ?? targetContact.Name;
        targetContact.MobilePhone =
            request.MobilePhone ?? targetContact.MobilePhone;
        targetContact.JobTitle = request.JobTitle ?? targetContact.JobTitle;
        targetContact.BirthDate = request.BirthDate ?? targetContact.BirthDate;

        targetContact.UpdatedAt = DateTimeOffset.Now;

        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}