using Application.Common.Interface;
using Application.ViewModel;
using MediatR;

namespace Application.Command.Auth;

public class CreateRegisterCommandHandler : IRequestHandler<CreateRegisterCommand,bool>
{
    
    private readonly IIdentityService _identityService;

    public CreateRegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        var dto = new RegisterViewModel.RegisterInput
        {
            Email = request.Email,
            UserName = request.UserName,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var (succeeded, errors) = await _identityService.RegisterAsync(dto);

        if (!succeeded)
            throw new Exception(string.Join(", ", errors));

        return true;
    }
}