using ContactsManager.Application.Models.ViewModels;
using MediatR;

namespace ContactsManager.Application.Requests.Contacts.Queries.GetContact;

public class GetContactQuery : IRequest<ContactVm>
{
    public Guid Id { get; set; }
}