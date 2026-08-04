using MediatR;

namespace Application.Command.Service;

public class UpdateServiceCommand : IRequest
{
    public int Id { get; set; }
    public int ProviderId { get;  set; }
    public string Title { get;  set; }
    public string Duration { get;  set; }
    public decimal Price { get;  set; }
}