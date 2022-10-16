using Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Workout
{
    public class WorkoutRecord
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public ActivityType ActivityType { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime Date { get; set; }
        public double Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public int Calories { get; set; }
    }
}
