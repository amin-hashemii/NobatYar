using Application.Common.Interface;
using Application.ViewModel;
using MediatR;

namespace Application.Command.Schedule;

public class CreateScheduleCommandHandler 
    : IRequestHandler<CreateScheduleCommand>
{
    private readonly IScheduleService _scheduleService;

    public CreateScheduleCommandHandler(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }


    public Task<Unit> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}