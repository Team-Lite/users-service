using Microsoft.EntityFrameworkCore;
using UsersService.Domain.Entities;

namespace UsersService.External.Database;

public sealed class ProfilesDbContext(DbContextOptions<ProfilesDbContext> options) : DbContext(options)
{
    public DbSet<UserProfile> Profiles { get; init; }
}