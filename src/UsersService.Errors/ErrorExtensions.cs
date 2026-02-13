using FluentResults;

namespace UsersService.Errors;

public static class ErrorExtensions
{
    extension(IError error)
    {
        public (string ErrorCode, string Message) Deconstruct()
        {
            string errorCode = error.Metadata["ErrorCode"].ToString() ?? "unknown";
            string message = error.Message;
            
            return (errorCode, message);
        }
    }
}