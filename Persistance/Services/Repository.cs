using Application.Interfaces;
using Common;
using Microsoft.EntityFrameworkCore;
using Persistance.SqlExceptionHandlers;
using System.Linq;

namespace Persistance
{
    [MapServiceDependency(nameof(Repository))]
    public class Repository : IRepository
    {
        private readonly IDbContext context;
        private ISqlExceptionHandler exceptionHandler;

        public Repository(IDbContext context, ISqlExceptionHandler exceptionHandler)
        {
            this.context = context;
            this.exceptionHandler = exceptionHandler;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(context, exceptionHandler);
        }

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return context.Set<T>().AsNoTracking();
        }
    }
}