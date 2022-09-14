using AutoMapper;
using ContactsManager.Application.Exceptions;
using ContactsManager.Application.Interfaces;
using ContactsManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactsManager.Application.Requests.Contacts.Commands.DeleteContact;

public class DeleteContactCommandHandler
    : BaseHandler, IRequestHandler<DeleteContactCommand>
{
    public DeleteContactCommandHandler(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    public async Task<Unit> Handle(DeleteContactCommand request,
        CancellationToken cancellationToken)
    {
        var targetContact =
            await DbContext.Contacts
                .FirstOrDefaultAsync(contact => contact.Id == request.Id,
                    cancellationToken)
            ?? throw new NotFoundException(nameof(Contact), request.Id);

        DbContext.Contacts.Remove(targetContact);
        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}