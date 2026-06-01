using Application.Command.ChangeRole;
using Application.Common.Interface;
using Application.ViewModel;
using MediatR;

namespace Application.Service;

public class AdminService : IAdminService
{
    private readonly IMediator _mediator;

    public AdminService(IMediator mediator)
    {
        _mediator = mediator;
    }


    public Task UpdateRole(ChangeRoleViewModel.ChangeRoleInput changeRoleInput)
    {
       var result= _mediator.Send(new ChangeUserRoleCommand()
        {
            UserId = changeRoleInput.UserId,
            NewRole = changeRoleInput.Role,
        });
       return result;
    }
}