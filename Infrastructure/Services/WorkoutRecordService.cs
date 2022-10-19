using Application.Interfaces;
using Application.Interfaces.WorkoutRecord;
using Application.Models.WorkoutRecordModels;
using Common;
using Domain.Entities;
using Domain.Entities.Workout;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    [MapServiceDependency(nameof(WorkoutRecordService))]
    public class WorkoutRecordService : IWorkoutRecordService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IFitnessDbContext _fitnessDbContext;
        public readonly IRepository _repository;
    
        public WorkoutRecordService(IUnitOfWork unitOfWork, IFitnessDbContext fitnessDbContext, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _fitnessDbContext = fitnessDbContext;
            _repository = repository;
        }

        public async Task<WorkoutRecordModel> AddWorkoutRecordAsync(AddWorkoutRecordModel newRecord)
        {
            var activityType = (ActivityTypeEnum)newRecord.Activity.ActivityType;
            var activity = await _unitOfWork.FindActivityTypeAsync(activityType);

            var workoutRecord = new WorkoutRecord
            {
                Id = Guid.NewGuid(),
                UserId = newRecord.UserId.ToString(),
                ActivityId = activity.Id,
                Date = DateTime.Now,
                Distance = newRecord.Distance,
                Duration = new TimeSpan(newRecord.Duration.Hours, newRecord.Duration.Minutes, newRecord.Duration.Seconds),
                Calories = newRecord.Calories
            };

            await _unitOfWork.AddAsync<WorkoutRecord>(workoutRecord);
            await _unitOfWork.SaveChangesAsync();

            return await Task.FromResult(new WorkoutRecordModel
            {
                Id = workoutRecord.Id,
                UserId = Guid.Parse(workoutRecord.UserId),
                Date = workoutRecord.Date,
                Distance = workoutRecord.Distance,
                Duration = workoutRecord.Duration,
                Calories = workoutRecord.Calories,
                ActivityType = activity.Type
            }) ;
        }

        public async Task<OverviewModel> GetAllWorkoutRecordsAsync(string userId)
        {
            var workoutRecords = await _unitOfWork.FindWorkoutRecordsByUserId(userId);

            var monthWorkoutRecords = workoutRecords.Select(u => new WorkoutRecordModel
            {
                Id = u.Id,
                UserId = Guid.Parse(u.UserId),
                ActivityType = u.ActivityType.Type,
                Duration = u.Duration,
                Distance = u.Distance,
                Date = u.Date,
                Calories = u.Calories
            }).OrderByDescending(e => e.Date).GroupBy(e => new { e.Date.Year, e.Date.Month }).ToList();

            var monthSummaryList = monthWorkoutRecords.Select(e =>
            {
                var monthWorkoutRecords = e.ToList();
                return new MonthSummaryModel
                {
                    Month = e.Key.Month,
                    Year = e.Key.Year,
                    TotalDistance = monthWorkoutRecords.Select(e => e.Distance).Sum(),
                    TotalTime = monthWorkoutRecords.Select(e => e.Duration.TotalMinutes).Sum(),
                    NumberOfTimes = monthWorkoutRecords.Count(),
                    Calories = monthWorkoutRecords.Select(e => e.Calories).Sum(),
                    WorkoutRecords = monthWorkoutRecords
                };
            }).ToList();

            var overview = new OverviewModel();
            overview.Duration = monthSummaryList.Select(e => e.TotalTime).Sum()/60.0;
            overview.NumberOfSessions = monthSummaryList.Select(e => e.NumberOfTimes).Sum();
            overview.Calories = monthSummaryList.Select(e => e.Calories).Sum();
            overview.MonthSummaries = monthSummaryList;
            return overview;
        }
    }

}
