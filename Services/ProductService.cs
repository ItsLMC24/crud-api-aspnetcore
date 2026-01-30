using CRUD_API.DTOs;
using CRUD_API.Models;
using CRUD_API.Repositories;
using CRUD_API.Services;

namespace CRUD_API.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo) => _repo = repo;

    public async Task<List<ProductReadDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        return products.Select(p => new ProductReadDto(p.Id, p.Name, p.Price)).ToList();
    }

    public async Task<ProductReadDto?> GetByIdAsync(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        return product is null ? null : new ProductReadDto(product.Id, product.Name, product.Price);
    }

    public async Task<ProductReadDto> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product { Name = dto.Name, Price = dto.Price };
        var created = await _repo.AddAsync(product);
        return new ProductReadDto(created.Id, created.Name, created.Price);
    }

    public async Task<bool> UpdateAsync(int id, ProductUpdateDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is null) return false;

        var updated = new Product { Id = id, Name = dto.Name, Price = dto.Price };
        return await _repo.UpdateAsync(updated);
    }

    public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
}
