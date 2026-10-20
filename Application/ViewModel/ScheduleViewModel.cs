namespace Application.ViewModel;

public class ScheduleViewModel
{
    public class CreateScheduleViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
    }
    public class UpdateScheduleViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
    }
    public class ScheduleOutput
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public bool IsActive { get; set; }

        
    //    public List<TimeSlotViewModel> TimeSlots { get; set; } = new();
    }
}