namespace Domain.Model.Appointment;

public class Appointment
{
    // اسلاتی که رزرو شده
    public int TimeSlotId { get; private set; }

    // کاربری که رزرو کرده
    public int UserId { get; private set; }

    // تاریخ رزرو (مثلاً 1405/05/20)
    public DateOnly Date { get; private set; }

    // وضعیت نوبت
    public AppointmentStatus Status { get; private set; }

    public TimeSlot.TimeSlot TimeSlot { get; private set; } = null!;

    public ApplicationUser User { get; private set; } = null!;
}