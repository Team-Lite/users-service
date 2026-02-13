using FluentResults;
using UsersService.Domain.Entities;

namespace UsersService.Application.Services;

public interface IProfileService
{
    Task<UserProfile?> GetUserProfileByIdAsync(Guid userId);
    
    Task<Result> CreateUserProfileAsync(Guid userId, string shownName);

    Task<Result> UpdateUserProfileStatusAsync(Guid userId, string newStatus);
}