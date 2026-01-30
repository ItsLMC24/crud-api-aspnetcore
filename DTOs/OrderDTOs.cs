namespace CRUD_API.DTOs;

public record OrderCreateDto(int UserId, int ProductId, int Quantity);
public record OrderReadDto(int Id, int UserId, int ProductId, int Quantity, DateTime CreatedAt);