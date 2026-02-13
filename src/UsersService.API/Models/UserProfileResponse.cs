using UsersService.Domain.Entities;

namespace UsersService.API.Models;

public sealed record UserProfileResponse(
    Guid Id,
    string Status)
{
    public static UserProfileResponse Create(UserProfile profile)
    {
        return new UserProfileResponse(
            profile.Id,
            profile.Status);
    } 
}