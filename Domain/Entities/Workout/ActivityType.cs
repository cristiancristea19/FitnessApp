using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Workout
{
    public class ActivityType : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ActivityTypeEnum Type { get; set; }
        public IEnumerable<WorkoutRecord> WorkoutRecords { get; set; }
    }
}
