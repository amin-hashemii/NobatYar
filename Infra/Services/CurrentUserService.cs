using System.Security.Claims;
using Application.Common.Interface;
using Microsoft.AspNetCore.Http;

namespace Infra.Services;

public class CurrentUserService : ICurrentUserService
{
    
    private readonly IHttpContextAccessor  _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId =>_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public bool IsAuthenticated =>_httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    
    
    /*
     When a valid JWT hits the API, ASP.NET Core (after UseAuthentication()) populates the user’s claims into HttpContext.User.
     CurrentUserService uses IHttpContextAccessor to access that HttpContext.User from anywhere in the app (services, handlers, etc.).
    It reads the NameIdentifier claim to get the current UserId and uses Identity.IsAuthenticated to know whether the user is logged in.
     */
    
    
    
    
}