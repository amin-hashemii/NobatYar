using Application.ViewModel;

namespace Application.Common.Interface;

public interface IAuthService
{
    Task Register(RegisterViewModel.RegisterInput input);
    Task<LoginViewModel.LoginResponseDto> Login(LoginViewModel.LoginInput input);

}