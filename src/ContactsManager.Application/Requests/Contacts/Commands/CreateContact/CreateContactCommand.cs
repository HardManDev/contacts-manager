using MediatR;

namespace ContactsManager.Application.Requests.Contacts.Commands.CreateContact;

public class CreateContactCommand : IRequest<Guid>
{
    public string Name { get; set; } = null!;
    public string MobilePhone { get; set; } = null!;

    public string? JobTitle { get; set; }

    public DateTimeOffset? BirthDate { get; set; }
}