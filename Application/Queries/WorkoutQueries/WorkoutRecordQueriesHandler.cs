using Application.Interfaces.WorkoutRecord;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries.WorkoutQueries;
using static Application.Queries.WorkoutQueries.WorkoutRecordQueries;
using System.Threading;

namespace Application.Queries.WorkoutQueries
{
    public class WorkoutRecordQueryHandler : IRequestHandler<GetWorkoutRecordsQuery, GetWorkoutRecordsQueryResponse>
    {

        private readonly IWorkoutRecordService _workoutRecordService;

        public WorkoutRecordQueryHandler(IWorkoutRecordService workoutRecordService)
        {
            _workoutRecordService = workoutRecordService;

        }

        public async Task<GetWorkoutRecordsQueryResponse> Handle(GetWorkoutRecordsQuery request, CancellationToken cancellationToken)
        {
            var workoutRecords = await _workoutRecordService.GetAllWorkoutRecordsAsync(request.UserId);
            return new GetWorkoutRecordsQueryResponse { WorkoutRecords = workoutRecords };
        }
    }
}
