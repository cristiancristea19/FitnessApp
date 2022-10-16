using Domain.Entities;
using Domain.Entities.Workout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IRepository, IDisposable
    {
        void SaveChanges();

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        public Task<IQueryable<T>> GetEntitiesAsync<T>() where T : class;

        public Task<T> FindByIdAsync<T>(Guid id) where T : class;

        Task AddAsync<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void BeginTransactionScope();

        Task<ActivityType> FindActivityTypeAsync(ActivityTypeEnum type);

        Task<List<Domain.Entities.Workout.WorkoutRecord>> FindWorkoutRecordsByUserId(string userId);
    }
}