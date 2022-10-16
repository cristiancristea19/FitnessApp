﻿using Application.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Runtime.Serialization;

namespace Persistance.SqlExceptions
{
    [Serializable]
    public class DeleteConstraintRepositoryViolationException : RepositoryViolationException
    {
        public DeleteConstraintRepositoryViolationException()
        {
        }

        public DeleteConstraintRepositoryViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        public DeleteConstraintRepositoryViolationException(SqlException exception)
            : base(exception)
        {
        }

        public DeleteConstraintRepositoryViolationException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected DeleteConstraintRepositoryViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}