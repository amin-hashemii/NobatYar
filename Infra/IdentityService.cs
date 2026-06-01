using Application.Common.Interface;
using Application.ViewModel;
using Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Infra;

public class IdentityService : IIdentityService 
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _roleManager = roleManager;
    }

    public async Task<(bool Succeeded, string? Token, LoginViewModel.LoginResponseDto? User)> LoginAsync(LoginViewModel.LoginInput input)
    {
        var user = await _userManager.FindByNameAsync(input.UserName);
        if (user == null) return (false, null, null);

        var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
        if (!result.Succeeded) return (false, null, null);

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.CreateToken(user, roles);

        return (true, token, new LoginViewModel.LoginResponseDto(token, user.UserName!, user.Email!));
    }
    

    public async Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(RegisterViewModel.RegisterInput input)
    {
        var user = new ApplicationUser
        {
            UserName = input.UserName,
            Email = input.Email,
            FirstName = input.FirstName,
            LastName = input.LastName,
            CreatedAt = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(user, input.Password);
        await _userManager.AddToRoleAsync(user, "User");
        if (!result.Succeeded)
        {
            return (false, result.Errors.Select(e => e.Description));
        }

      

        return (true, Array.Empty<string>());
    }

    public async Task<(bool Succeeded, IEnumerable<string> Errors)> ChangeUserRoleAsync(ChangeRoleViewModel.ChangeRoleInput input)
    {
        var newRole = input.Role.ToString();
        
        var roleExists = await _roleManager.RoleExistsAsync(newRole);
        if (!roleExists)
            return (false, new[] { $"Role '{newRole}' does not exist." });

        // 2. پیدا کردن کاربر
        var user = await _userManager.FindByIdAsync(input.UserId);
        if (user == null)
            return (false, new[] { "User not found." });

        // 3. گرفتن نقش‌های فعلی و حذف آن‌ها (برای اینکه فقط یک نقش داشته باشد)
        var currentRoles = await _userManager.GetRolesAsync(user);
        if (currentRoles.Any())
        {
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
                return (false, removeResult.Errors.Select(e => e.Description));
        }

        // 4. اضافه کردن نقش جدید
        var addResult = await _userManager.AddToRoleAsync(user, newRole);
        if (!addResult.Succeeded)
            return (false, addResult.Errors.Select(e => e.Description));

        return (true, Array.Empty<string>());
    }
}