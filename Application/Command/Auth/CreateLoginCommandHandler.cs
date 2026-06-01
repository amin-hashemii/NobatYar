using Application.Common.Interface;
using Application.ViewModel;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Command.Auth;

public class CreateLoginCommandHandler:IRequestHandler<CreateLoginCommand,LoginViewModel.LoginResponseDto>
{
    private readonly IIdentityService _identityService;

    public CreateLoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<LoginViewModel.LoginResponseDto> Handle(CreateLoginCommand request,
        CancellationToken cancellationToken)
    {
        var input = new LoginViewModel.LoginInput
        {
            UserName = request.UserName,
            Password = request.Password
        };

        var (succeeded, token, userDto) = await _identityService.LoginAsync(input);

        if (!succeeded || userDto is null)
            throw new UnauthorizedAccessException("Invalid username or password");

        return userDto;
    }
}