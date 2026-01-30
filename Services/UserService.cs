using CRUD_API.DTOs;
using CRUD_API.Models;
using CRUD_API.Repositories;
using CRUD_API.Services;

namespace CRUD_API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) => _repo = repo;

    public async Task<List<UserReadDto>> GetAllAsync()
    {
        var users = await _repo.GetAllAsync();
        return users.Select(u => new UserReadDto(u.Id, u.FullName, u.Email)).ToList();
    }

    public async Task<UserReadDto?> GetByIdAsync(int id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user is null ? null : new UserReadDto(user.Id, user.FullName, user.Email);
    }

    public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
    {
        var user = new User { FullName = dto.FullName, Email = dto.Email };
        var created = await _repo.AddAsync(user);
        return new UserReadDto(created.Id, created.FullName, created.Email);
    }

    public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;

        var updated = new User { Id = id, FullName = dto.FullName, Email = dto.Email };
        return await _repo.UpdateAsync(updated);
    }

    public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
}
