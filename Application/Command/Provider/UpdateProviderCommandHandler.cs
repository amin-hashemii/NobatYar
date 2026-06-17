using Application.Configuration.Exceptions;
using Domain.Repository;
using MediatR;

namespace Application.Command.Provider;

public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand>
{
    private readonly IProviderRepository _providerRepository;

    public UpdateProviderCommandHandler(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<Unit> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
    {
       var provider = await _providerRepository.GetAsync(request.Id);
       if (provider == null)
           throw new MyApplicationException(ApplicationErrors.ProviderNotFound);
       provider.Update(request.CategoryId,request.Name,request.Bio,request.Address);
       _providerRepository.Update(provider);
       await _providerRepository.UnitOfWork.Commit();
       return Unit.Value;
    }
}