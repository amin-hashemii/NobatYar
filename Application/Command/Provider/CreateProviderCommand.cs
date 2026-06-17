using MediatR;
using NetDevPack.SimpleMediator.Core.Interfaces;

namespace Application.Command.Provider;

public class CreateProviderCommand : IRequest
{
    public string UserId { get; set; }
    public int CategoryId { get;  set; }
    public string Name { get;  set; }
    public string Bio { get;  set; }
    public string Address { get;  set; }
}