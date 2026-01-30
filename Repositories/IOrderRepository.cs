using CRUD_API.Models;

namespace CRUD_API.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> AddAsync(Order order);
    Task<bool> DeleteAsync(int id);
}

