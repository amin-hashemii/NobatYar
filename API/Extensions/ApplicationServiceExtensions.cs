using Application.Common.Interface;
using Application.Query.Account;
using Application.Service;
using Infra;
using Infra.Services;
using MediatR;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Application.AssemblyReference).Assembly);
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddHttpContextAccessor();   
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        return services;
    }
}