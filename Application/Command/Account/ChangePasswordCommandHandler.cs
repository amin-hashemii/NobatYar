using Application.Common.Interface;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Command.Account;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand,bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICurrentUserService _currentUser;
   

    public ChangePasswordCommandHandler(UserManager<ApplicationUser> userManager, ICurrentUserService currentUser)
    {
        _userManager = userManager;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var userid = _currentUser.UserId;
        var user = await _userManager.FindByIdAsync(userid);
        var result =await _userManager.ChangePasswordAsync(user,request.OldPassword, request.NewPassword);
        if (result.Succeeded == false)
        {
            throw new Exception("failed to change password");
        }

        return true;
    }
}