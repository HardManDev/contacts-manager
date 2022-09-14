using ContactsManager.Application.Models.ViewModels;
using MediatR;

namespace ContactsManager.Application.Requests.Contacts.Queries.GetContactList;

public class GetContactListQuery : IRequest<IList<ContactVm>>
{
    public int? Count { get; set; }
    public int? Offset { get; set; }
}