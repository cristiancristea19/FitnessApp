using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.WorkoutRecordModels
{
    public class ActivityModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ActivityTypeEnum Type { get; set; }
    }

    public class AddWorkoutRecordActivityModel
    {
        public ActivityTypeEnum ActivityType { get; set; }
    }
}
