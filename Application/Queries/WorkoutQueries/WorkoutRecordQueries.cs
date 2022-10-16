using Application.Common;
using Application.Models.WorkoutRecordModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.WorkoutQueries
{
    public class WorkoutRecordQueries
    {
        public class GetWorkoutRecordsQuery : BaseRequest<GetWorkoutRecordsQueryResponse>
        {
            public string UserId { get; set; }
        }

        public class GetWorkoutRecordsQueryResponse
        {
            public List<WorkoutRecordModel> WorkoutRecords { get; set; }
        }
    }
}
