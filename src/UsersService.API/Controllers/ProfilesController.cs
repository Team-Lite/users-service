using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersService.API.Extensions;
using UsersService.API.Models;
using UsersService.Application.Services;
using UsersService.Domain.Entities;

namespace UsersService.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public sealed class ProfilesController : ControllerBase
{
    private readonly IProfileService _profileService;
    
    public ProfilesController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetUserProfileAsync()
    {
        Guid userId = User.GetId();

        UserProfile? profile = await _profileService.GetUserProfileByIdAsync(userId);

        if (profile is null) return NotFound();
        
        UserProfileResponse response = UserProfileResponse.Create(profile);
        
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserProfileByIdAsync(Guid id)
    {
        UserProfile? profile = await _profileService.GetUserProfileByIdAsync(id);

        if (profile is null) return NotFound();

        UserProfileResponse response = UserProfileResponse.Create(profile);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserProfileAsync(NewUserProfileRequest request)
    {
        Guid userId = User.GetId();

        Result result = await _profileService
            .CreateUserProfileAsync(userId, request.ShownName);

        if (result.IsSuccess) return Ok();

        return BadRequest(ApiResult.Bind(result));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStatusAsync(NewStatusRequest request)
    {
        Guid userId = User.GetId();
        
        Result result = await _profileService.UpdateUserProfileStatusAsync(userId, request.Status);

        if (result.IsSuccess) return Ok();

        return BadRequest(ApiResult.Bind(result));
    }
}