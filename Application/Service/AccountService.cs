using Application.Command.Account;
using Application.Common.Interface;
using Application.Query;
using Application.Query.Account;
using Application.ViewModel;
using MediatR;

namespace Application.Service;

public class AccountService : IAccountService
{
    
    private readonly IMediator _mediator;

    public AccountService(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task<AccountViewModel.MyProfileOutPut> GetMyProfile(string userid)
    {
        var result = await _mediator.Send(new GetProfileQuery()
        {
            id = userid,
        });
     return result;
    }

    public async Task UpdateMyProfile(AccountViewModel.ChangePassInput Input)
    {
        await _mediator.Send(new ChangePasswordCommand()
        {
            OldPassword = Input.OldPassword,
            NewPassword = Input.NewPassword,
        });
    }
    
}