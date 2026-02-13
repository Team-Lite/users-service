using FluentResults;

namespace UsersService.Errors.ApplicationErrors;

public sealed class UniqueViolationError : Error
{
    public UniqueViolationError()
    {
        Message = "Unique constraint violation occurred";
        Metadata.Add("ErrorCode", "UniqueViolation");
    }
}