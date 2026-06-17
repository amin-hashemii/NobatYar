using Application.ViewModel;
using Domain.Repository;
using MediatR;

namespace Application.Query.Provider;

public class GetAllProviderQuery : IRequest<List<ProviderViewModel.GetProviderOutput>>
{
    
}