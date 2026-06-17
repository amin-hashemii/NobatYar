using Application.ViewModel;
using Domain.Repository;
using MediatR;

namespace Application.Query.Provider;

public class GetAllProviderQueryHandler : IRequestHandler<GetAllProviderQuery,List<ProviderViewModel.GetProviderOutput>>
{
    private readonly IProviderRepository _repository;

    public GetAllProviderQueryHandler(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProviderViewModel.GetProviderOutput>> Handle(GetAllProviderQuery request, CancellationToken cancellationToken)
    {
     var result =  await  _repository.GetAllAsync();
    return result.Select(x => new ProviderViewModel.GetProviderOutput
     {
         UserId = x.UserId,
         Name = x.Name,
         Address = x.Address,
         CategoryId = x.CategoryId,
         Bio = x.Bio,
     }).ToList();
    }
}