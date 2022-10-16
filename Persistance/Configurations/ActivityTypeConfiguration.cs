using Domain.Entities.Workout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class ActivityTypeConfiguration :IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.ToTable("ActivityTypes");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property<string>(e => e.Name).IsRequired();
        }
    }
}
