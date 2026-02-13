using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace UsersService.External.Database.Extensions;

public static class DbUpdateExceptionExtensions
{
    extension(DbUpdateException exception)
    {
        public bool IsUniqueViolation()
        {
            return exception.InnerException is PostgresException { SqlState: "23505" };
        }
    }
}