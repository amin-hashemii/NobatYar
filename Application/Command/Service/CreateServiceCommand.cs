using MediatR;
using NetDevPack.SimpleMediator.Core.Interfaces;

namespace Application.Command.Service;

public class CreateServiceCommand : IRequest
{
    public int ProviderId { get;  set; }
    public string Title { get;  set; }
    public string Duration { get;  set; }
    public decimal Price { get;  set; }
    
}