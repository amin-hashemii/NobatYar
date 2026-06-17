using Domain.Repository;
using MediatR;

namespace Application.Command.Provider;

public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand>
{
    private readonly IProviderRepository _providerRepository;

    public CreateProviderCommandHandler(IProviderRepository providerRepository)
    {
        _providerRepository = providerRepository;
    }

    public async Task<Unit> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
       var result = new Domain.Model.Provider.Provider(request.UserId,request.CategoryId,request.Name,request.Bio, request.Address);
       await _providerRepository.AddAsync(result);
       await _providerRepository.UnitOfWork.Commit();
       return Unit.Value;
    }
}