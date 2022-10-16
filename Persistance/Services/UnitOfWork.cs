using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Authentication;
using Domain.Entities.Workout;
using Microsoft.EntityFrameworkCore;
using Persistance.SqlExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transactionScope;
        private IDbContext dbContext;
        private ISqlExceptionHandler exceptionHandler;

        public UnitOfWork(IDbContext dbContext, ISqlExceptionHandler exceptionHandler)
        {
            this.dbContext = dbContext;
            this.exceptionHandler = exceptionHandler;
        }

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public async Task<IQueryable<T>> GetEntitiesAsync<T>() where T : class
        {
            return await Task.FromResult(dbContext.Set<T>());
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return this;
        }

        public void SaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
                if (_transactionScope != null)
                    _transactionScope.Complete();
            }
            catch (Exception e)
            {
                Handle(e);
            }
        }

        private void Handle(Exception exception)
        {
            exceptionHandler.Handle(exception);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await dbContext.SaveChangesAsync(cancellationToken);

                if (_transactionScope != null)
                {
                    _transactionScope.Complete();
                }
            }
            catch (Exception e)
            {
                Handle(e);
            }
        }

        public async Task<ActivityType> FindActivityTypeAsync(ActivityTypeEnum type)
        {
            return await dbContext.Set<ActivityType>().Where(e => e.Type == type).FirstOrDefaultAsync();
        }

        public async Task<List<WorkoutRecord>> FindWorkoutRecordsByUserId(string userId)
        {
            var workoutRecords = await dbContext.Set<WorkoutRecord>().Where(e => e.UserId == userId).ToListAsync();
            workoutRecords.ForEach(e => e.ActivityType = FindById<ActivityType>(e.ActivityId));
            return workoutRecords;
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await Task.FromResult(dbContext.Set<T>().Add(entity));
        }

        public T FindById<T>(Guid id) where T : class
        {
            return dbContext.Set<T>().Find(id);
        }

        public async Task<T> FindByIdAsync<T>(Guid id) where T : class
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public void Delete<T>(T entity) where T : class
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void BeginTransactionScope()
        {
            if (_transactionScope != null)
                throw new InvalidOperationException("Cannot begin another transaction scope");

            _transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_transactionScope != null)
                    _transactionScope.Dispose();
            }
        }
    }
}