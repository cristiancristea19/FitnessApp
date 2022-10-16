using Application.Exceptions;
using Common;
using Microsoft.Data.SqlClient;
using Persistance.SqlExceptions;
using System;

namespace Persistance.SqlExceptionHandlers
{
    [MapServiceDependency(nameof(SqlExceptionHandler))]
    public class SqlExceptionHandler : ISqlExceptionHandler
    {
        public void Handle(Exception exception)
        {
            var sqlException = exception.InnerException as SqlException;
            if (sqlException != null)
            {
                switch (sqlException.Number)
                {
                    case 242:
                        throw new DateTimeRangeRepositoryViolationException(sqlException);
                    case 547:
                        throw new DeleteConstraintRepositoryViolationException(sqlException);
                    case 1205:
                        throw new DeadlockVictimRepositoryViolationException(sqlException);
                    case 2601:
                    case 2627:
                        throw new UniqueConstraintRepositoryViolationException(sqlException);
                    default:
                        throw new RepositoryViolationException(sqlException);
                }
            }

            throw new RepositoryViolationException(exception);
        }
    }
}