using FluentResults;

namespace UsersService.Errors.ApplicationErrors;

public sealed class EntityNotFoundError : Error
{
    public EntityNotFoundError()
    {
        Message = "Entity was not found";
        Metadata.Add("ErrorCode", "EntityNotFound");
    }
}