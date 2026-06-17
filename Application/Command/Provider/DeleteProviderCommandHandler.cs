using Application.Configuration.Exceptions;
using Domain.Repository;
using MediatR;

namespace Application.Command.Provider;

public class DeleteProviderCommandHandler : IRequestHandler<DeleteProviderCommand>
{
    private readonly IProviderRepository _providerRepository;

    public DeleteProviderCommandHandler(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<Unit> Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
    {
        var Category = await _providerRepository.GetAsync(request.Id);
        if (Category == null)
            throw new MyApplicationException(ApplicationErrors.ProviderNotFound);
         _providerRepository.Remove(Category);
         await _providerRepository.UnitOfWork.Commit();
         return Unit.Value;
    }
}