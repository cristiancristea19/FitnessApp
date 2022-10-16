using Application.Interfaces;
using Application.Interfaces.WorkoutRecord;
using Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.WorkoutRecordCommands
{
    [MapServiceDependency(Name: nameof(WorkoutRecordCommandHandler))]
    public class WorkoutRecordCommandHandler : IRequestHandler<AddWorkoutRecordCommand, AddWorkoutRecordCommandResponse>
    {
        private readonly IWorkoutRecordService _workoutRecordService;
        private readonly IRepository _repository;

        public WorkoutRecordCommandHandler(IWorkoutRecordService workoutRecordService, IRepository repository)
        {
            _workoutRecordService = workoutRecordService;
            _repository = repository;
        }

        public async Task<AddWorkoutRecordCommandResponse> Handle(AddWorkoutRecordCommand request, CancellationToken cancellationToken)
        {
            var workoutRecord = await _workoutRecordService.AddWorkoutRecordAsync(request.WorkoutRecord);
            if (workoutRecord != null)
            {
                return new AddWorkoutRecordCommandResponse { WorkoutRecord = workoutRecord };
            }
            return null;
        }
    }
}
