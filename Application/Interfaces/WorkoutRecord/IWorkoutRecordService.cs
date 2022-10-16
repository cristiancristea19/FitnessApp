using Application.Models.WorkoutRecordModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.WorkoutRecord
{
    public interface IWorkoutRecordService
    {
        Task<WorkoutRecordModel> AddWorkoutRecordAsync(AddWorkoutRecordModel newRecord);
        Task<List<WorkoutRecordModel>> GetAllWorkoutRecordsAsync(string userId);
    }
}
