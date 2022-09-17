using System.Diagnostics;
using AutoMapper;
using ContactsManager.Application.Models.ViewModels;
using ContactsManager.Application.Requests.Contacts.Commands.CreateContact;
using ContactsManager.Application.Requests.Contacts.Commands.DeleteContact;
using ContactsManager.Application.Requests.Contacts.Commands.UpdateContact;
using ContactsManager.Application.Requests.Contacts.Queries.GetContact;
using ContactsManager.Application.Requests.Contacts.Queries.GetContactList;
using ContactsManager.Models;
using ContactsManager.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(IMapper mapper, ILogger<HomeController> logger)
        : base(mapper)
    {
        _logger = logger;
    }

    public async Task<ViewResult> Index()
    {
        var contacts =
            await Mediator.Send(new GetContactListQuery());

        return View((List<ContactVm>)contacts);
    }

    public PartialViewResult GetCreateContactModalPartial()
    {
        return PartialView("CreateContactModal");
    }

    public async Task<PartialViewResult> GetEditContactModalPartial(Guid id)
    {
        Console.WriteLine(id);

        var contact = await Mediator.Send(new GetContactQuery
        {
            Id = id
        });

        return PartialView("EditContactModal", contact);
    }

    public async Task<RedirectResult> CreateContact(
        CreateContactDto createContactDto)
    {
        // TODO: Stub logic.
        if (!ModelState.IsValid) return Redirect("/");

        var command = Mapper.Map<CreateContactCommand>(createContactDto);
        await Mediator.Send(command);

        return Redirect("/");
    }

    public async Task<RedirectResult> UpdateContact(
        UpdateContactDto updateContactDto)
    {
        // TODO: Stub logic.
        if (!ModelState.IsValid) return Redirect("/");

        var command = Mapper.Map<UpdateContactCommand>(updateContactDto);
        await Mediator.Send(command);

        return Redirect("/");
    }

    public async Task<RedirectResult> DeleteContact(Guid id)
    {
        await Mediator.Send(new DeleteContactCommand
        {
            Id = id
        });

        return Redirect("/");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
        NoStore = true)]
    public ViewResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}