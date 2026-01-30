using CRUD_API.DTOs;

namespace CRUD_API.Services;

public interface IProductService
{
    Task<List<ProductReadDto>> GetAllAsync();
    Task<ProductReadDto?> GetByIdAsync(int id);
    Task<ProductReadDto> CreateAsync(ProductCreateDto dto);
    Task<bool> UpdateAsync(int id, ProductUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
