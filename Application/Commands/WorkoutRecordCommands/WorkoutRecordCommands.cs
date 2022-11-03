using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.WorkoutRecordModels;

namespace Application.Commands.WorkoutRecordCommands
{
    public class AddWorkoutRecordCommand : BaseRequest<AddWorkoutRecordCommandResponse>
    {
        public AddWorkoutRecordModel WorkoutRecord { get; set; }
    }
    
    public class AddWorkoutRecordCommandResponse
    {
        public WorkoutRecordModel WorkoutRecord { get; set; }
    }

    public class EditWorkoutRecordCommand : BaseRequest<EditWorkoutRecordCommandResponse>
    {
        public EditWorkoutRecordModel WorkoutRecord { get; set; }
    }

    public class EditWorkoutRecordCommandResponse
    {
        public bool IsSuccessful { get; set; }
    }
}
