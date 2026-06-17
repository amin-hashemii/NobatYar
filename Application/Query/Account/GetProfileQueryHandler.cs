using Application.Common.Interface;
using Application.Configuration.Exceptions;
using Application.ViewModel;
using Domain.Repository;
using MediatR;

namespace Application.Query.Account;

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery,AccountViewModel.MyProfileOutPut>
{
    
    private readonly IAccountRepository _accountRepository;

    public GetProfileQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountViewModel.MyProfileOutPut> Handle( GetProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _accountRepository.GetAccount(request.id);

        if (user == null)
        throw new MyApplicationException(ApplicationErrors.UserNotFound);

        return new AccountViewModel.MyProfileOutPut
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Username = user.UserName
        };
        
    }
}