using Application.ViewModel;
using MediatR;

namespace Application.Command.Auth;

public class CreateLoginCommand :IRequest<LoginViewModel.LoginResponseDto>
{
    public string UserName{get;set;}
    public string Password {get;set;}
}