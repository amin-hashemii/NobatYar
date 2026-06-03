using Application.ViewModel;

namespace Application.Common.Interface;

public interface IAccountRepository
{
    Task<AccountViewModel.MyProfileOutPut> GetAccount(string userid);
    
}