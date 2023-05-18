using Jumbula.Domain.Entities.Account;
using Jumbula.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Jumbula.Application;

namespace Jumbula.Infrastructure.Extensions;
public static class IdentityConfigurations
{
    public static void AddCustomIdentity(this IServiceCollection services, IdentitySettings settings)
    {
        services.AddIdentity<User, Role>(identityOptions =>
        {
            //Password Settings
            identityOptions.Password.RequireDigit = settings.PasswordRequireDigit;
            identityOptions.Password.RequiredLength = settings.PasswordRequiredLength;
            identityOptions.Password.RequireNonAlphanumeric = settings.PasswordRequireNonAlphanumeric; 
            identityOptions.Password.RequireUppercase = settings.PasswordRequireUppercase;
            identityOptions.Password.RequireLowercase = settings.PasswordRequireLowercase;

            //UserName Settings
            identityOptions.User.RequireUniqueEmail = settings.RequireUniqueEmail;

            //Lockout Settings
            identityOptions.Lockout.MaxFailedAccessAttempts = 5;
            identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            identityOptions.Lockout.AllowedForNewUsers = false;
        })
        .AddEntityFrameworkStores<DataContext>()
        .AddDefaultTokenProviders();
    }
}