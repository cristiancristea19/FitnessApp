using Application.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Runtime.Serialization;

namespace Persistance.SqlExceptions
{
    [Serializable]
    public class DeadlockVictimRepositoryViolationException : RepositoryViolationException
    {
        public DeadlockVictimRepositoryViolationException()
        {
        }

        public DeadlockVictimRepositoryViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        public DeadlockVictimRepositoryViolationException(SqlException exception)
            : base(exception)
        {
        }

        public DeadlockVictimRepositoryViolationException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected DeadlockVictimRepositoryViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}