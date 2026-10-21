using Domain.Model.Services;

namespace Domain.Model.Appointment;

public class Appointment : BaseModel<int>
{
   

    // اسلاتی که رزرو شده
    public int TimeSlotId { get; private set; }

    // خدمتی که رزرو شده
    public int ServiceId { get; private set; }

    // کاربری که رزرو کرده
    public string UserId { get; private set; }

    // تاریخ رزرو (مثلاً 1405/05/20)
    public DateOnly Date { get; private set; }

    // وضعیت نوبت
    public AppointmentStatus Status { get; private set; }

    public TimeSlot.TimeSlot TimeSlot { get; private set; } = null!;

    public Service Service { get; private set; } = null!;

    public ApplicationUser User { get; private set; } = null!;

    // برای EF Core لازمه (Materialization)
    private Appointment() { }

    // برای ساخت از بیرون کلاس، با اعتبارسنجی اولیه
    public static Appointment Create(int timeSlotId, int serviceId, string userId, DateOnly date)
    {
        return new Appointment
        {
            TimeSlotId = timeSlotId,
            ServiceId = serviceId,
            UserId = userId,
            Date = date,
            Status = AppointmentStatus.Pending
        };
    }

    // متدهای رفتاری به‌جای ست کردن مستقیم Status از بیرون
    public void Confirm()
    {
        if (Status != AppointmentStatus.Pending)
            throw new InvalidOperationException("فقط نوبت در وضعیت Pending قابل تایید است.");

        Status = AppointmentStatus.Confirmed;
    }

    public void Cancel()
    {
        if (Status == AppointmentStatus.Completed)
            throw new InvalidOperationException("نوبت انجام‌شده قابل لغو نیست.");

        Status = AppointmentStatus.Cancelled;
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Confirmed)
            throw new InvalidOperationException("فقط نوبت تاییدشده قابل تکمیل است.");

        Status = AppointmentStatus.Completed;
    }

    public void MarkAsNoShow()
    {
        if (Status != AppointmentStatus.Confirmed)
            throw new InvalidOperationException("فقط نوبت تاییدشده قابل ثبت به‌عنوان عدم‌حضور است.");

        Status = AppointmentStatus.NoShow;
    }
}