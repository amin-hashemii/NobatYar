using Application.ViewModel;
using MediatR;

namespace Application.Query.Account;

public class GetProfileQuery: IRequest<AccountViewModel.MyProfileOutPut>
{
    public string id { get; set; }
}