using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<IEnumerable<Users>> GetAllUsersAsync()
    {
        var users = await context.Users.ToListAsync() ?? throw new Exception("Nenhum usuário encontrado!");
        return users;
    }
    
    public async Task<Users> GetUserByIdAsync(int id)
    {
        var user = await context.Users.FindAsync(id) ?? throw new Exception("Usuário não encontrado!");
        return user;
    }

    public async Task<Users> InsertUserAsync(Users user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<Users> UpdateUserAsync(int id, Users user)
    {
        var existingUser = await context.Users.FindAsync(user.Id) ?? throw new Exception("Usuário não encontrado!");
        existingUser.Id = id;
        context.Users.Entry(existingUser).CurrentValues.SetValues(user);
        await context.SaveChangesAsync();
        return existingUser;
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id) ?? throw new Exception("Usuário não encontrado!");
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }
}