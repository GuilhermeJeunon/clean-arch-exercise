using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<Users>> GetAllUsersAsync();

    Task<Users> GetUserByIdAsync(int id);

    Task<Users> InsertUserAsync(Users user);

    Task<Users> UpdateUserAsync(int id, Users user);

    Task DeleteUserAsync(int id);
}