using MediatR;
using NetDevPack.SimpleMediator.Core.Interfaces;

namespace Application.Command.Schedule;

public class CreateScheduleCommand : IRequest
{
    public DayOfWeek DayOfWeek { get; set; }
}