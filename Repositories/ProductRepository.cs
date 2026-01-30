using CRUD_API.Data;
using CRUD_API.Models;
using CRUD_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;
    public ProductRepository(AppDbContext db) => _db = db;

    public async Task<List<Product>> GetAllAsync() =>
        await _db.Products.AsNoTracking().ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) =>
        await _db.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Product> AddAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        _db.Products.Update(product);
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product is null) return false;
        _db.Products.Remove(product);
        return await _db.SaveChangesAsync() > 0;
    }
}
