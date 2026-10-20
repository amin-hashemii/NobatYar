using MediatR;

namespace Application.Command.Schedule;

public class ChangeScheduleStatusCommand : IRequest
{
    public int ScheduleId { get; set; }

    public bool IsActive { get; set; }
}