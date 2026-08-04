namespace Domain.Model.Schedule;

public class Schedule : BaseModel<int>
{
    // شناسه ارائه‌دهنده خدمت
    public int ProviderId { get; private set; }

    // روز هفته
    public DayOfWeek DayOfWeek { get; private set; }

    // فعال یا غیرفعال بودن برنامه کاری
    public bool IsActive { get; private set; }

    public Provider.Provider Provider { get; private set; } = null!;

    public ICollection<TimeSlot.TimeSlot> TimeSlots { get; private set; } = new List<TimeSlot.TimeSlot>();
}