using System;

namespace Persistance.SqlExceptionHandlers
{
    public interface ISqlExceptionHandler
    {
        void Handle(Exception exception);
    }
}