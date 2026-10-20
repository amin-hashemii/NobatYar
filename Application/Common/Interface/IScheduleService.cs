using Application.ViewModel;

namespace Application.Common.Interface;

public interface IScheduleService
{
    Task<ScheduleViewModel> CreateAsync(string userId, ScheduleViewModel.CreateScheduleViewModel input);

    Task<ScheduleViewModel?> GetByIdAsync(string userId, int scheduleId);

    Task<List<ScheduleViewModel>> GetMySchedulesAsync(string userId);

    Task<ScheduleViewModel> UpdateAsync(string userId, int scheduleId, ScheduleViewModel.UpdateScheduleViewModel model);
  
    Task<bool> ChangeStatusAsync(string userId, int scheduleId, bool isActive);

    Task<bool> DeleteAsync(string userId, int scheduleId);
}