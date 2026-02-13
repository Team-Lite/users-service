using FluentResults;
using Microsoft.EntityFrameworkCore;
using UsersService.Domain.Entities;
using UsersService.Errors.ApplicationErrors;
using UsersService.External.Database;
using UsersService.External.Database.Extensions;

namespace UsersService.Application.Services;

internal sealed class ProfileService : IProfileService
{
    private readonly ProfilesDbContext _context;
    
    public ProfileService(ProfilesDbContext context)
    {
        _context = context;
    }
    
    public Task<UserProfile?> GetUserProfileByIdAsync(Guid userId) => 
        _context.Profiles.FirstOrDefaultAsync(p => p.Id == userId);

    public async Task<Result> CreateUserProfileAsync(Guid userId, string shwonName)
    {
        UserProfile userProfile = UserProfile.CreateWithId(userId, shwonName);

        _context.Profiles.Add(userProfile);

        try
        {
            await _context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (DbUpdateException exception)
        {
            if (exception.IsUniqueViolation()) 
                return Result.Fail(new UniqueViolationError());
            throw;
        }
    }

    public async Task<Result> UpdateUserProfileStatusAsync(Guid userId, string newStatus)
    {
        UserProfile? profile = await _context
            .Profiles
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (profile is null) return Result.Fail(new EntityNotFoundError());

        profile.UpdateStatus(newStatus);

        await _context.SaveChangesAsync();

        return Result.Ok();
    }
}