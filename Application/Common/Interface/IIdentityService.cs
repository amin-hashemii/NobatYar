using Application.ViewModel;
using Domain.Enum;

namespace Application.Common.Interface;

public interface IIdentityService
{
    Task<(bool Succeeded, string? Token, LoginViewModel.LoginResponseDto? User)> LoginAsync(LoginViewModel.LoginInput loginDto);
    Task<(bool Succeeded, IEnumerable<string> Errors)> RegisterAsync(RegisterViewModel.RegisterInput input);
    Task<(bool Succeeded, IEnumerable<string> Errors)> ChangeUserRoleAsync(ChangeRoleViewModel.ChangeRoleInput input);
}