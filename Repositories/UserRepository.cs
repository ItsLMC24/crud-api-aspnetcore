using CRUD_API.Data;
using CRUD_API.Models;
using CRUD_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) => _db = db;

    public async Task<List<User>> GetAllAsync() =>
        await _db.Users.AsNoTracking().ToListAsync();

    public async Task<User?> GetByIdAsync(int id) =>
        await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<User> AddAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        _db.Users.Update(user);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return false;
        _db.Users.Remove(user);
        return await _db.SaveChangesAsync() > 0;
    }
}
