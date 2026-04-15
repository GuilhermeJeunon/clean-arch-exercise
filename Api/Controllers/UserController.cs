using AutoMapper;
using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Validation;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, IMapper mapper, UserDtoValidator validator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = await userService.GetAllUsersAsync();
        return Ok(mapper.Map<IEnumerable<UserDto>>(users));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var user = await userService.GetUserByIdAsync(id);
        return Ok(mapper.Map<UserDto>(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userDto)
    {
        var newUser = mapper.Map<Users>(userDto);
        
        var validationResult = await validator.ValidateAsync(userDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
        
        var createdUser = await userService.InsertUserAsync(newUser);
        
        return Ok(mapper.Map<UserDto>(createdUser));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UserDto userDto)
    {
        var user = mapper.Map<Users>(userDto);
        
        var validationResult = await validator.ValidateAsync(userDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
        
        var updatedUser = await userService.UpdateUserAsync(id, user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        await userService.DeleteUserAsync(id);
        return NoContent();
    }
}