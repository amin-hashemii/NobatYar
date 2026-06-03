using Application.ViewModel;

namespace Application.Common.Interface;

public interface IAccountService
{
    Task<AccountViewModel.MyProfileOutPut> GetMyProfile(string userid);
    Task UpdateMyProfile(AccountViewModel.ChangePassInput Input);
}