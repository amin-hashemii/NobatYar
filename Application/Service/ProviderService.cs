using Application.Command.Provider;
using Application.Common.Interface;
using Application.Query.Category;
using Application.Query.Provider;
using Application.ViewModel;
using MediatR;

namespace Application.Service;

public class ProviderService : IProviderService
{
    
    private readonly IMediator _mediator;

    public ProviderService(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task CreateProvider(ProviderViewModel.CreateProviderInput input)
    {
        await _mediator.Send(new CreateProviderCommand()
        {
            Address = input.Address,
            Name = input.Name,
            Bio = input.Bio,
            CategoryId = input.CategoryId,
            UserId = input.UserId
        });
    }

    public async Task DeleteProvider(int id)
    {
        await _mediator.Send(new DeleteProviderCommand()
        {
            Id = id
        });
    }

    public async Task UpdateProvider(ProviderViewModel.UpdateProviderInput input)
    {
        await _mediator.Send(new UpdateProviderCommand()
        {
            Address = input.Address,
            Name = input.Name,
            Bio = input.Bio,
            CategoryId = input.CategoryId,
            Id = input.Id
        });
    }

    public async Task<List<ProviderViewModel.GetProviderOutput>> GetAllProviders()
    {
       return await _mediator.Send(new GetAllProviderQuery() { });
        
    }

    public async Task<ProviderViewModel.GetProviderOutput> GetProviderById(int id)
    {
        return await _mediator.Send(new GetByIdProviderQuery()
        {
            Id = id
        });
    }
}