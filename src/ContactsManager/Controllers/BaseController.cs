using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.Controllers;

public class BaseController : Controller
{
    protected readonly IMapper Mapper;

    public BaseController(IMapper mapper)
    {
        Mapper = mapper;
    }

    protected IMediator Mediator =>
        HttpContext.RequestServices.GetRequiredService<IMediator>();
}