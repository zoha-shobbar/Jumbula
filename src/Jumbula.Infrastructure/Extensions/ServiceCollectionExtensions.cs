using Jumbula.Application.Services.EntityServices;
using Jumbula.Application.Services.EntityServices.Common;
using Jumbula.Domain.Repositories.Common;
using Jumbula.Infrastructure.Repositories.Common;
using Jumbula.Infrastructure.Services.EntityServices;
using Jumbula.Infrastructure.Services.Jwt;
using LMS.Infrastructure.Services.EntityServices.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Jumbula.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddJumbulaServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<IAccountService, AccountService>();
    }
}
