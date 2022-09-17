using System.Diagnostics;
using AutoMapper;
using ContactsManager.Application.Requests.Contacts.Queries.GetContactList;
using ContactsManager.Models;
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

        return View(contacts);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}