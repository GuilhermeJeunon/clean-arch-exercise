using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<IEnumerable<Users>> GetAllUsersAsync() => await repository.GetAllUsersAsync();
    
    public async Task<Users> GetUserByIdAsync(int id) => await repository.GetUserByIdAsync(id);
    
    public async Task<Users> InsertUserAsync(Users user) => await repository.InsertUserAsync(user);

    public async Task<Users> UpdateUserAsync(int id, Users user) => await repository.UpdateUserAsync(id, user);
    
    public async Task DeleteUserAsync(int id) => await repository.DeleteUserAsync(id);
}