using MediatR;

namespace Application.Command.Schedule;

public class DeleteScheduleCommand : IRequest
{
    public int ScheduleId { get; set; }
}