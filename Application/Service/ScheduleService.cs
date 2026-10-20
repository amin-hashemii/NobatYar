using Application.Common.Interface;
using Application.ViewModel;

namespace Application.Service;

public class ScheduleService : IScheduleService
{
    
    public Task<ScheduleViewModel> CreateAsync(string userId, ScheduleViewModel.CreateScheduleViewModel input)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduleViewModel?> GetByIdAsync(string userId, int scheduleId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ScheduleViewModel>> GetMySchedulesAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduleViewModel> UpdateAsync(string userId, int scheduleId, ScheduleViewModel.UpdateScheduleViewModel model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeStatusAsync(string userId, int scheduleId, bool isActive)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string userId, int scheduleId)
    {
        throw new NotImplementedException();
    }
}