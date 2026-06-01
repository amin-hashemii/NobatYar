using Domain.Enum;
using MediatR;

namespace Application.Command.ChangeRole;

public class ChangeUserRoleCommand : IRequest<bool>
{
    public string UserId { get; set; }
    public AppRole NewRole { get; set; }
}