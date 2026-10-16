using Domain.Model.Schedule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuration;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.DayOfWeek)
            .IsRequired()
            .HasConversion<string>()   // enum به صورت رشته ذخیره میشه، خوانا‌تر در دیتابیس
            .HasMaxLength(20);

        builder.Property(s => s.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // رابطه با Provider — هر Provider چند Schedule داره
        builder.HasOne(s => s.Provider)
            .WithMany(p => p.Schedules)
            .HasForeignKey(s => s.ProviderId)
            .OnDelete(DeleteBehavior.Cascade); // اگه Provider حذف بشه، Schedule هاش هم حذف بشن

        // جلوگیری از تعریف دوباره‌ی یه روز برای یه Provider (مثلاً دو تا Schedule برای دوشنبه)
        builder.HasIndex(s => new { s.ProviderId, s.DayOfWeek })
            .IsUnique();
    }
}