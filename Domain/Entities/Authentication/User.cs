using Domain.Entities.Workout;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain.Entities.Authentication
{
    public class User : IdentityUser
    {
        public char Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public IEnumerable<WorkoutRecord> WorkoutRecords { get; set; }
    }
}