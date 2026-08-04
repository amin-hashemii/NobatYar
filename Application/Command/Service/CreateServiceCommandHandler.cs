using Domain.Repository;
using MediatR;

namespace Application.Command.Service;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IServiceRepository _serviceRepository;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Domain.Model.Services.Service
            (request.ProviderId, request.Title, request.Duration, request.Price);
       await _serviceRepository.AddAsync(service);
        await _serviceRepository.UnitOfWork.Commit();
        return Unit.Value;
    }
}