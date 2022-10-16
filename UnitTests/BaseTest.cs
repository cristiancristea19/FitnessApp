using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Persistance.SqlExceptionHandlers;

namespace UnitTests
{
    public class BaseTest
    {
        public BaseTest()
        {
            ServiceCollection = new ServiceCollection();
            ServiceProvider = ServiceCollection.BuildServiceProvider();

            var dbContext = DbContextFactory.CreateDbContext();
            var sqlExceptionHandler = new SqlExceptionHandler();
            var repository = new Repository(dbContext, sqlExceptionHandler);
            ServiceCollection.AddSingleton(typeof(IRepository), repository);
        }

        public ServiceCollection ServiceCollection { get; protected set; }

        public ServiceProvider ServiceProvider { get; protected set; }
    }
}