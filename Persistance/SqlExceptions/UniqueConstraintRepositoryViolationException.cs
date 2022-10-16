using Application.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Runtime.Serialization;

namespace Persistance.SqlExceptions
{
    [Serializable]
    public class UniqueConstraintRepositoryViolationException : RepositoryViolationException
    {
        public UniqueConstraintRepositoryViolationException()
        {
        }

        public UniqueConstraintRepositoryViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        public UniqueConstraintRepositoryViolationException(SqlException exception)
            : base(exception)
        {
        }

        public UniqueConstraintRepositoryViolationException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected UniqueConstraintRepositoryViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}