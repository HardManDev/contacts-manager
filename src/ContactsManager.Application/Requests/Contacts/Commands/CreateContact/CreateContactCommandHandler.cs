using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Domain.Entities;
using MediatR;

namespace ContactsManager.Application.Requests.Contacts.Commands.CreateContact;

public class CreateContactCommandHandler
    : BaseHandler, IRequestHandler<CreateContactCommand, Guid>
{
    public CreateContactCommandHandler(IMapper mapper,
        IApplicationDbContext dbContext)
        : base(mapper, dbContext)
    {
    }

    public async Task<Guid> Handle(CreateContactCommand request,
        CancellationToken cancellationToken)
    {
        Contact newContact = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            MobilePhone = request.MobilePhone,
            JobTitle = request.JobTitle,
            BirthDate = request.BirthDate,
            CreatedAt = DateTimeOffset.Now,
            UpdatedAt = null
        };

        await DbContext.Contacts.AddAsync(newContact, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return newContact.Id;
    }
}