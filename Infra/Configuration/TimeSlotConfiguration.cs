using Domain.Model.TimeSlot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configuration;

public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
{

    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {
        
        builder.Property(t => t.StartTime)
            .IsRequired();

        builder.Property(t => t.EndTime)
            .IsRequired();

        builder.Property(t => t.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // رابطه با Schedule — هر Schedule چند TimeSlot داره
        builder.HasOne(t => t.Schedule)
            .WithMany(s => s.TimeSlots)
            .HasForeignKey(t => t.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade);

        // قانون: EndTime باید بعد از StartTime باشه (Check Constraint در سطح دیتابیس)
        builder.ToTable(t => t.HasCheckConstraint(
            "CK_TimeSlot_EndTime_After_StartTime",
            "[EndTime] > [StartTime]"));

        // جلوگیری از تداخل دقیق دو بازه‌ی زمانی یکسان توی یه Schedule
        // (تداخل جزئی رو باید در سطح سرویس چک کنی، این فقط جلوی تکرار کامل رو میگیره)
        builder.HasIndex(t => new { t.ScheduleId, t.StartTime, t.EndTime })
            .IsUnique();
    }
}