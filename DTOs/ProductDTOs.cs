namespace CRUD_API.DTOs;

public record ProductCreateDto(string Name, decimal Price);
public record ProductUpdateDto(string Name, decimal Price);
public record ProductReadDto(int Id, string Name, decimal Price);