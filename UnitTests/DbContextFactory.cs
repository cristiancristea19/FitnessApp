using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace UnitTests
{
    public class DbContextFactory
    {
        public static FitnessDbContext CreateDbContext()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var optionsBuilder = new DbContextOptionsBuilder<FitnessDbContext>().UseSqlite(connection);

            var dbContext = new FitnessDbContext(optionsBuilder.Options);
            dbContext.Database.OpenConnection();

            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}