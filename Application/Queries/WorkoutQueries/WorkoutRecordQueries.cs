using Application.Common;
using Application.Models.WorkoutRecordModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.WorkoutQueries
{
    public class GetWorkoutRecordByIdQuery : BaseRequest<GetWorkoutRecordByIdQueryResponse>
    {
        public Guid WorkoutId { get; set; }
    }

    public class GetWorkoutRecordByIdQueryResponse
    {
        public WorkoutRecordModel Workout { get; set; }
    }

    public class GetWorkoutRecordsQuery : BaseRequest<GetWorkoutRecordsQueryResponse>
    {
        public string UserId { get; set; }
    }

    public class GetWorkoutRecordsQueryResponse
    {
        public OverviewModel Overview { get; set; }
    }

    public class FilterByActivityTypeQuery : BaseRequest<FilterByActivityTypeQueryResponse>
    {
        public string UserId { get; set; }
        public int ActivityType { get; set; }
    }

    public class FilterByActivityTypeQueryResponse
    {
        public OverviewModel Overview { get; set; }
    }
}
