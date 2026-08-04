namespace Domain.Model.TimeSlot;

public class TimeSlot : BaseModel<int>
{
    public int ScheduleId { get; private set; }

    // ساعت شروع این اسلات
    public TimeOnly StartTime { get; private set; }

    // ساعت پایان این اسلات
    public TimeOnly EndTime { get; private set; }

    // قابل رزرو بودن اسلات
    public bool IsActive { get; private set; }

    public Schedule.Schedule Schedule { get; private set; } = null!;

    public ICollection<Appointment.Appointment> Appointments { get; private set; } = new List<Appointment.Appointment>();
}