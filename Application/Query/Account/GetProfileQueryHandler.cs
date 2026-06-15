using Application.Common.Interface;
using Application.ViewModel;
using MediatR;

namespace Application.Query.Account;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery,AccountViewModel.MyProfileOutPut>
{
    
    private readonly IAccountRepository _accountRepository;

    public GetProfileQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountViewModel.MyProfileOutPut> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _accountRepository.GetAccount(request.id);

        if (user == null)
            throw new Exception("User not found");

        return user;
    }
}