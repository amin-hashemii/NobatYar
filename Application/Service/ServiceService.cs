using Application.Command.Category;
using Application.Command.Service;
using Application.Common.Interface;
using Application.ViewModel;
using NetDevPack.SimpleMediator.Core.Interfaces;
using IMediator = MediatR.IMediator;

namespace Application.Service;

public class ServiceService : IServiceService
{
    
    private readonly MediatR.IMediator _mediator;

    public ServiceService(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task CreateService(ServiceViewModel.CreateServiceInput input)
    {
        await _mediator.Send(new CreateServiceCommand()
        {
            Duration = input.Duration,
            Price = input.Price,
            ProviderId = input.ProviderId,
            Title = input.Title,
        });
    }

    public async Task DeleteService(int id)
    {
        await _mediator.Send(new DeleteServiceCommand()
        {
            Id = id
        });
    }

    public async Task UpdateService(ServiceViewModel.UpdateServiceInput input)
    {
        await _mediator.Send(new UpdateServiceCommand()
        {
            Duration = input.Duration,
            Price = input.Price,
            ProviderId = input.ProviderId,
            Title = input.Title,
            Id = input.Id
        });
    }

    public Task<List<ServiceViewModel.GetAllService>> GetService()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceViewModel.GetAllService> GetServiceById(int id)
    {
        throw new NotImplementedException();
    }
}