namespace Domain.Model.Appointment;

public enum AppointmentStatus
{
    Pending,      // رزرو شده، هنوز تایید نشده
    Confirmed,    // توسط Provider تایید شده
    Cancelled,    // لغو شده (توسط هرکدوم از طرفین)
    Completed,    // نوبت انجام شده
    NoShow        // کاربر نیومده سر وقت
}