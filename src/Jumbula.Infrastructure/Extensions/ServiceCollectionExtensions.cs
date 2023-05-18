using Jumbula.Application.Services.EntityServices;
using Jumbula.Infrastructure.Services.EntityServices;
using Microsoft.Extensions.DependencyInjection;

namespace Jumbula.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddJumbulaServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
    }
}
