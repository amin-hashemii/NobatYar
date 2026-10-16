using Domain.Model.Appointment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.Property(a => a.Date)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion<string>()   // enum به صورت رشته ذخیره میشه
            .HasMaxLength(20);

        // رابطه با TimeSlot
        builder.HasOne(a => a.TimeSlot)
            .WithMany(t => t.Appointments)
            .HasForeignKey(a => a.TimeSlotId)
            .OnDelete(DeleteBehavior.Restrict); // نذار با حذف TimeSlot، رزروها هم پاک بشن

        // رابطه با Service
        builder.HasOne(a => a.Service)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        // رابطه با کاربر رزرو‌کننده
        builder.HasOne(a => a.User)
            .WithMany(u => u.Appointments)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // مهم‌ترین بخش: جلوگیری از تداخل زمانی (Double Booking)
        // یه TimeSlot توی یه Date مشخص فقط یه رزرو فعال (غیر Cancelled) می‌تونه داشته باشه
        builder.HasIndex(a => new { a.TimeSlotId, a.Date })
            .IsUnique()
            .HasFilter("[Status] <> 'Cancelled'");
    }
}
