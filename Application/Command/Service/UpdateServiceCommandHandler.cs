using Application.Configuration.Exceptions;
using Domain.Repository;
using MediatR;

namespace Application.Command.Service;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    
    private readonly IServiceRepository _serviceRepository;

    public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var result = await _serviceRepository.GetAsync(request.Id);
        if(result == null)
        {
            throw new MyApplicationException(ApplicationErrors.ServiceNotFound);
        }
        result.UpdateService(request.ProviderId,request.Title,request.Duration,request.Price);
        _serviceRepository.Update(result);
        return Unit.Value;
    }
}