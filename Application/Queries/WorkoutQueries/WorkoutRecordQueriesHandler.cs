using Application.Interfaces.WorkoutRecord;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries.WorkoutQueries;
using System.Threading;

namespace Application.Queries.WorkoutQueries
{
    public class WorkoutRecordQueryHandler : IRequestHandler<GetWorkoutRecordsQuery, GetWorkoutRecordsQueryResponse>,
        IRequestHandler<FilterByActivityTypeQuery, FilterByActivityTypeQueryResponse>,
        IRequestHandler<GetWorkoutRecordByIdQuery, GetWorkoutRecordByIdQueryResponse>
    {

        private readonly IWorkoutRecordService _workoutRecordService;

        public WorkoutRecordQueryHandler(IWorkoutRecordService workoutRecordService)
        {
            _workoutRecordService = workoutRecordService;

        }

        public async Task<GetWorkoutRecordByIdQueryResponse> Handle(GetWorkoutRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var workoutRecord = await _workoutRecordService.GetWorkoutRecordByIdAsync(request.WorkoutId);
            return new GetWorkoutRecordByIdQueryResponse { Workout = workoutRecord };
        }

        public async Task<GetWorkoutRecordsQueryResponse> Handle(GetWorkoutRecordsQuery request, CancellationToken cancellationToken)
        {
            var overview = await _workoutRecordService.GetAllWorkoutRecordsAsync(request.UserId);
            return new GetWorkoutRecordsQueryResponse { Overview = overview };
        }

        public async Task<FilterByActivityTypeQueryResponse> Handle(FilterByActivityTypeQuery request, CancellationToken cancellationToken)
        {
            var overview = await _workoutRecordService.FilterByActivityTypeAsync(request.UserId, request.ActivityType);
            return new FilterByActivityTypeQueryResponse { Overview = overview };
        }
    }
}
