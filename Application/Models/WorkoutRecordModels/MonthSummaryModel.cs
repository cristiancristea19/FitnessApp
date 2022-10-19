using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.WorkoutRecordModels
{
    public class MonthSummaryModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public double TotalDistance { get; set; }
        public double TotalTime { get; set; }
        public int NumberOfTimes { get; set; }
        public int Calories { get; set; }
        public List<WorkoutRecordModel> WorkoutRecords { get; set; }
    }
}
