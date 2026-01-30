using CRUD_API.Data;
using CRUD_API.Models;
using CRUD_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;
    public OrderRepository(AppDbContext db) => _db = db;

    public async Task<List<Order>> GetAllAsync() =>
        await _db.Orders.AsNoTracking().ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) =>
        await _db.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Order> AddAsync(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order is null) return false;
        _db.Orders.Remove(order);
        return await _db.SaveChangesAsync() > 0;
    }
}
