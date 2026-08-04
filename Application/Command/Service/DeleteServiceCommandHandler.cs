using Application.Configuration.Exceptions;
using Domain.Repository;
using MediatR;

namespace Application.Command.Service;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
{
    
    private readonly IServiceRepository _serviceRepository;

    public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
      var result= await _serviceRepository.GetAsync(request.Id);
      if(result == null)
      {
          throw new MyApplicationException(ApplicationErrors.ServiceNotFound);
      }
      _serviceRepository.Remove(result); 
      await _serviceRepository.UnitOfWork.Commit();
      return Unit.Value;
    }
}