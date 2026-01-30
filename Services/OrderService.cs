using CRUD_API.DTOs;
using CRUD_API.Models;
using CRUD_API.Repositories;
using CRUD_API.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CRUD_API.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo) => _repo = repo;

    public async Task<List<OrderReadDto>> GetAllAsync()
    {
        var orders = await _repo.GetAllAsync();
        return orders.Select(o => new OrderReadDto(o.Id, o.UserId, o.ProductId, o.Quantity, o.CreatedAt)).ToList();
    }

    public async Task<OrderReadDto?> GetByIdAsync(int id)
    {
        var order = await _repo.GetByIdAsync(id);
        return order is null ? null : new OrderReadDto(order.Id, order.UserId, order.ProductId, order.Quantity, order.CreatedAt);
    }

    public async Task<OrderReadDto> CreateAsync(OrderCreateDto dto)
    {
        var order = new Order { UserId = dto.UserId, ProductId = dto.ProductId, Quantity = dto.Quantity };
        var created = await _repo.AddAsync(order);
        return new OrderReadDto(created.Id, created.UserId, created.ProductId, created.Quantity, DateTime.UtcNow);
    }

    public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
}
