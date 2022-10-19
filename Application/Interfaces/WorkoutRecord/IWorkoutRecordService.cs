﻿using Application.Models.WorkoutRecordModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces.WorkoutRecord
{
    public interface IWorkoutRecordService
    {
        Task<WorkoutRecordModel> AddWorkoutRecordAsync(AddWorkoutRecordModel newRecord);
        Task<OverviewModel> GetAllWorkoutRecordsAsync(string userId);
    }
}
