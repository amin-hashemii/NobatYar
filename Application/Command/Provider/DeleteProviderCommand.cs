using MediatR;

namespace Application.Command.Provider;

public class DeleteProviderCommand : IRequest
{
    public int Id {get;set;}
}