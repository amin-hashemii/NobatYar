using MediatR;

namespace Application.Command.Provider;

public class UpdateProviderCommand : IRequest
{
    public int Id { get;  set; }
    public int CategoryId { get;  set; }
    public string Name { get;  set; }
    public string Bio { get;  set; }
    public string Address { get;  set; }
}