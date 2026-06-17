using Application.ViewModel;
using MediatR;

namespace Application.Query.Provider;

public class GetByIdProviderQuery : IRequest<ProviderViewModel.GetProviderOutput>
{
    public int Id { get; set; }
}