using MediatR;

namespace ContactsManager.Application.Requests.Contacts.Commands.UpdateContact;

public class UpdateContactCommand : IRequest
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? MobilePhone { get; set; }

    public string? JobTitle { get; set; }

    public DateTimeOffset? BirthDate { get; set; }
}