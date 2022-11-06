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
    public class WorkoutRecordCommandHandler : IRequestHandler<AddWorkoutRecordCommand, AddWorkoutRecordCommandResponse>,
        IRequestHandler<EditWorkoutRecordCommand, EditWorkoutRecordCommandResponse>,
        IRequestHandler<DeleteWorkoutRecordCommand, Unit>
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

        public async Task<EditWorkoutRecordCommandResponse> Handle(EditWorkoutRecordCommand request, CancellationToken cancellationToken)
        {
            return new EditWorkoutRecordCommandResponse { IsSuccessful = await _workoutRecordService.EditWorkoutRecordAsync(request.WorkoutRecord) };
        }

        public async Task<Unit> Handle(DeleteWorkoutRecordCommand request, CancellationToken cancellationToken)
        {
            await _workoutRecordService.DeleteWorkoutRecordAsync(request.Id);
            return await Unit.Task;
        }
    }
}
