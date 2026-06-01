using Application.Command.Auth;
using Application.Common.Interface;
using Application.ViewModel;
using MediatR;

namespace Application.Service;

public class AuthService : IAuthService
{
    private readonly IMediator _mediator;

    public AuthService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Register(RegisterViewModel.RegisterInput input)
    {
        await _mediator.Send(new CreateRegisterCommand()
        {
            Password = input.Password,
            UserName = input.UserName,
            Email = input.Email,
            FirstName = input.FirstName,
            LastName = input.LastName,
        });
    }

    public async Task<LoginViewModel.LoginResponseDto> Login(LoginViewModel.LoginInput input)
    {
       var result = await _mediator.Send(new CreateLoginCommand()
        {
            Password = input.Password,
            UserName = input.UserName
        });
        return result;
    }
}