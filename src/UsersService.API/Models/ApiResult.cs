using FluentResults;
using UsersService.Errors;

namespace UsersService.API.Models;

public sealed record ApiError(string ErrorCode, string Message);

public sealed record ApiResult(IEnumerable<ApiError> Errors)
{
    public static ApiResult Bind(Result result)
    {
        IEnumerable<ApiError> errors = result
            .Errors
            .Select(error =>
            {
                (string errorCode, string message) = error.Deconstruct();

                return new ApiError(errorCode, message);
            });
        
        return new ApiResult(errors);
    }
}