using CRUD_API.DTOs;

namespace CRUD_API.Services;

public interface IUserService
{
    Task<List<UserReadDto>> GetAllAsync();
    Task<UserReadDto?> GetByIdAsync(int id);
    Task<UserReadDto> CreateAsync(UserCreateDto dto);
    Task<bool> UpdateAsync(int id, UserUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
