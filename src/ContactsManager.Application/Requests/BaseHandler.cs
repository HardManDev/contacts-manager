using AutoMapper;
using ContactsManager.Application.Interfaces;

namespace ContactsManager.Application.Requests;

public class BaseHandler
{
    protected readonly IApplicationDbContext DbContext;
    protected readonly IMapper Mapper;

    protected BaseHandler(IMapper mapper, IApplicationDbContext dbContext)
    {
        Mapper = mapper;
        DbContext = dbContext;
    }
}