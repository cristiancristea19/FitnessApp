using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.WorkoutRecordModels
{
    public class AddWorkoutRecordModel
    {
        public Guid UserId { get; set; }
        public double Distance { get; set; }
        public DurationModel Duration { get; set; }
        public int Calories { get; set; }
        public AddWorkoutRecordActivityModel Activity { get; set; }
    }

    public class WorkoutRecordModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public double Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public int Calories { get; set; }
        public ActivityTypeEnum ActivityType { get; set; }
    }
}
