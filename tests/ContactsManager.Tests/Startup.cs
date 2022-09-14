using System.Reflection;
using ContactsManager.Application;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Mappings;
using ContactsManager.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsManager.Tests;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
        });
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        services.AddAutoMapper(config =>
        {
            config.AddProfile(
                new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(
                new AssemblyMappingProfile(typeof(IApplicationDbContext)
                    .Assembly));
        });
    }
}