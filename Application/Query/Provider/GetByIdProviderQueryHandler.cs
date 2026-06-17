using Application.Configuration.Exceptions;
using Application.ViewModel;
using Domain.Repository;
using MediatR;

namespace Application.Query.Provider;

public class GetByIdProviderQueryHandler : IRequestHandler<GetByIdProviderQuery,ProviderViewModel.GetProviderOutput>
{
    private readonly IProviderRepository _repository;

    public GetByIdProviderQueryHandler(IProviderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProviderViewModel.GetProviderOutput> Handle(GetByIdProviderQuery request, CancellationToken cancellationToken)
    {
       var category = await _repository.GetAsync(request.Id);
       if (category == null)
           throw new MyApplicationException(ApplicationErrors.ProviderNotFound);
       return new ProviderViewModel.GetProviderOutput()
       {
           UserId = category.UserId,
           CategoryId = category.CategoryId,
           Name = category.Name,
           Bio = category.Bio,
           Address = category.Address,
       };
    }
}