using MediatR;

namespace Application.Command.Schedule;

public class UpdateScheduleCommand : IRequest
{
    public int ScheduleId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }
}