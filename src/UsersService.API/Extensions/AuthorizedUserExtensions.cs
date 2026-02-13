using System.Security.Claims;

namespace UsersService.API.Extensions;

public static class AuthorizedUserExtensions
{
    extension(ClaimsPrincipal user)
    {
        public Guid GetId()
        {
            string? userId = user.FindFirstValue("sub");
            
            ArgumentException.ThrowIfNullOrEmpty(userId);
            
            Guid convertedUserId = Guid.Parse(userId);
            
            return convertedUserId;
        }    
    }
}