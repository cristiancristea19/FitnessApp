using Application.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Runtime.Serialization;

namespace Persistance.SqlExceptions
{
    [Serializable]
    public class DateTimeRangeRepositoryViolationException : RepositoryViolationException
    {
        public DateTimeRangeRepositoryViolationException()
        {
        }

        public DateTimeRangeRepositoryViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        public DateTimeRangeRepositoryViolationException(SqlException exception)
            : base(exception)
        {
        }

        public DateTimeRangeRepositoryViolationException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected DateTimeRangeRepositoryViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}