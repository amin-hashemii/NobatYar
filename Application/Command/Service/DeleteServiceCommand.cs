using MediatR;

namespace Application.Command.Service;

public class DeleteServiceCommand : IRequest
{
    public int Id { get; set; }
}