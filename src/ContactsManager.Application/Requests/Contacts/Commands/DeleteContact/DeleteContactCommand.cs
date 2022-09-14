using MediatR;

namespace ContactsManager.Application.Requests.Contacts.Commands.DeleteContact;

public class DeleteContactCommand : IRequest
{
    public Guid Id { get; set; }
}