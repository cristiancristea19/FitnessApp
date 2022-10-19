using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.WorkoutRecordModels
{
    public class OverviewModel
    {
        public double Duration { get; set; }
        public int NumberOfSessions { get; set; }
        public int Calories { get; set; }
        public IEnumerable<MonthSummaryModel> MonthSummaries { get; set; }
    }
}
