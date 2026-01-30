using CRUD_API.DTOs;

namespace CRUD_API.Services;

public interface IOrderService
{
    Task<List<OrderReadDto>> GetAllAsync();
    Task<OrderReadDto?> GetByIdAsync(int id);
    Task<OrderReadDto> CreateAsync(OrderCreateDto dto);
    Task<bool> DeleteAsync(int id);
}
