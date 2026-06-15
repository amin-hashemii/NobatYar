using MediatR;

namespace Application.Command.Account;

public class ChangePasswordCommand : IRequest<bool>
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}