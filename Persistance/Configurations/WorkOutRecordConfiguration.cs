using Domain.Entities.Workout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistance.Configurations
{
    internal class WorkoutRecordConfiguration: IEntityTypeConfiguration<WorkoutRecord>
    {
        public void Configure(EntityTypeBuilder<WorkoutRecord> builder)
        {
            builder.ToTable("WorkoutRecords");
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(e => e.User).WithMany(e => e.WorkoutRecords).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.ActivityType).WithMany(e => e.WorkoutRecords).HasForeignKey(e => e.ActivityId);
        }
    }
}
