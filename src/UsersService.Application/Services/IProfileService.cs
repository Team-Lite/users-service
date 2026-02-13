using FluentResults;
using UsersService.Domain.Entities;

namespace UsersService.Application.Services;

internal interface IProfileService
{
    Task<UserProfile?> GetUserProfileByIdAsync(Guid userId);
    
    Task<Result> CreateUserProfileAsync(Guid userId);

    Task<Result> UpdateUserProfileStatus(Guid userId, string newStatus);
}