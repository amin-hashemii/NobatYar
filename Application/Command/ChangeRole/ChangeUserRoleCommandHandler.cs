using Application.Common.Interface;
using Application.ViewModel;
using MediatR;

namespace Application.Command.ChangeRole;

public class ChangeUserRoleCommandHandler:IRequestHandler<ChangeUserRoleCommand,bool>
{
    
    private readonly IIdentityService _identityService;

    public ChangeUserRoleCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
    {
        var input = new ChangeRoleViewModel.ChangeRoleInput
        {
            UserId = request.UserId,
            Role = request.NewRole
        };

        var (succeeded, errors) = await _identityService.ChangeUserRoleAsync(input);

        if (!succeeded)
            throw new Exception(string.Join(", ", errors));

        return true;
    }
}